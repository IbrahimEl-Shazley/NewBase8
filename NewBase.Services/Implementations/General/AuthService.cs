using AAITHelper;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Enums;
using NewBase.Core.ExtensionsMethods;
using NewBase.Core.Helpers.General;
using NewBase.Core.Helpers.Security;
using NewBase.Core.Models;
using NewBase.Repositories.Interfaces;
using NewBase.Repositories.UnitOfWork;
using NewBase.Service.Interfaces.General;
using NewBase.Services.DTOs.General;
using NewBase.Services.DTOs.Schema.SEC;
using NewBase.Services.Implementation;
using NewBase.Services.Implementation.General;
using NewBase.Services.Interfaces.General;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewBase.Services.Implementations.General
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly INotificationService _notificationService;




        public AuthService(IUnitOfWork uow,IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = (UserManager<ApplicationDbUser>)serviceProvider.GetService(typeof(UserManager<ApplicationDbUser>));
            _configuration = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
            _mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
            _userRepository = uow.Repository<IUserRepository>();
            _notificationService = (INotificationService)serviceProvider.GetService(typeof(INotificationService));
            _uow = (IUnitOfWork)serviceProvider.GetService(typeof(IUnitOfWork)); ;

        }


        public async Task<string> Login(UserLoginDto userLoginDTO)
        {
            //var user = await _userManager.FindByEmailAsync(userLoginDTO.Username);
            var user = await _userRepository.
                GetUser<ApplicationDbUser>(u => u.PhoneNumber.Equals(userLoginDTO.PhoneOrMail) || u.Email.Equals(userLoginDTO.PhoneOrMail))
                .FirstOrDefaultAsync();
            //await _userManager.FindByEmailAsync(userLoginDTO.Username);
            if (user == null)
                throw new BussinessRuleException("TheEmailOrPasswordIsIncorrectPleaseTryAgain");

            if (!await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                throw new BussinessRuleException("TheEmailOrPasswordIsIncorrectPleaseTryAgain");
            }
            return GenerateToken(user, userLoginDTO.RememberMe);

        }

        public async Task<UserInfo> Register(UserRegisterDTO userDTO, string UserType)
        {

            string EnglishPhoneNumber = null;
            string MobileRole = Enum.GetName(typeof(Roles), Roles.Mobile);
            bool mailExist, phoneExists;
            ApplicationDbUser user = new ApplicationDbUser();
            UserInfo userInfo = new UserInfo();

            EnglishPhoneNumber = HelperNumber.ConvertArabicNumberToEnglish(userDTO.PhoneNumber);

            mailExist = await _userRepository.MailExistsRegister(userDTO.UserName);
            phoneExists = await _userRepository.PhoneExistsBeforeRegister(EnglishPhoneNumber);

            #region Validations
            if (mailExist || phoneExists)
                throw new BussinessRuleException("ThisUserIsAlreadyExists");
            #endregion
            #region Registration Transaction 
            try
            {
                _userRepository.BeginTrnsactionAsync();
                #region MapUser
                user = _mapper.Map(userDTO, user);
                user.UserType = UserType;
                #endregion

                #region Save User 
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                #endregion
                if (!result.Succeeded)
                    throw new BussinessRuleException("Can'tRegister");

                #region AddRole
                IdentityResult RoleResult = await _userManager.AddToRoleAsync(user, MobileRole);
                #endregion


                #region OTP
                string OTP = OTPHelper.OTP();
                // TODO: change to default verification method
                var verificationMethod = NotificationTypeEnum.SMS;
                await _notificationService.Send(new Notification
                {
                    NotificationCategory = NotificationCategoryEnum.ActivateAccount,
                    To = verificationMethod == NotificationTypeEnum.Email ? user.Email : user.PhoneNumber,
                    Input = OTP
                }, verificationMethod);
                user.Code = OTP;
                //user.CodeExpiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["OTPExpiration"])); //in case of expiration 
                _userRepository.UpdateUser(user);
                await _uow.SaveChangeAsync();
                #endregion


                if (RoleResult.Succeeded)
                    _userRepository.CommitAsync();

                
            }
            catch (Exception ex)
            {
                _userRepository.RollBackAsync();
                throw new BussinessRuleException("Can'tRegister");
            }
            #endregion 

            userInfo = _mapper.Map(user, userInfo);

            userInfo.IsAuthenticated = true;
            userInfo.Roles = new List<string> { MobileRole };
            userInfo.Token = GenerateToken(user);
            userInfo.IsActive = false;

            return userInfo;

        }




        public async Task<bool> ActivateUser(string userId, UserVerifyDTO dto)
        {
            var user = await _userRepository.UserFirstOrDefaultAsync<ApplicationDbUser>(x => x.Id == userId, true);
            if (user == null)
                throw new BussinessRuleException("UserNotExist");
            if (user.IsActive)
                throw new BussinessRuleException("UserAlreadyActivated");

            var validToken = user.Code == dto.OTP ;
            if (!validToken)
                throw new BussinessRuleException("TokenIsNotValidOrExpired");

            user.IsActive = true; 
         
            _userRepository.UpdateUser(user);

            return await _uow.SaveChangeAsync();
        }


        public async Task<bool> ResendActivationOTP(string userId, NotificationTypeEnum verificationMethod)
        {
            var user = await _userRepository.UserFirstOrDefaultAsync<ApplicationDbUser>(x => x.Id == userId, true);
            if (user == null)
                throw new BussinessRuleException("UserNotExist");

            string OTP = OTPHelper.OTP();

            //var isSent = await _notificationService.Send(new Notification
            //{
            //    NotificationCategory = NotificationCategoryEnum.ActivateAccount,
            //    To = verificationMethod == NotificationTypeEnum.Email ? user.Email : user.PhoneNumber,
            //    Input = OTP
            //}, verificationMethod);

            //if (!isSent)
            //    throw new InternalServerException();

            user.Code = OTP;
           // user.OTPExpiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["OTPExpiration"]));
            _userRepository.UpdateUser(user);
            return await _uow.SaveChangeAsync();
        }


 
        public async Task<bool> ForgetPassword(ForgetPasswordDTO dto)
        {
            var user = await _userRepository.
                             GetUser<ApplicationDbUser>(u => u.PhoneNumber.Equals(dto.Phone) || u.Email.Equals(dto.Email))
                            .FirstOrDefaultAsync();
            if (user == null)
                throw new BussinessRuleException("TheIdentityIdIsNotCorrect");

            string OTP = OTPHelper.OTP();
            var isSent = await _notificationService.Send(new Notification
            {
                NotificationCategory = NotificationCategoryEnum.ResetPassword,
                To = dto.VerificationType == NotificationTypeEnum.Email ? user.Email : user.PhoneNumber,
                Input = OTP
            }, dto.VerificationType);

            if (!isSent)
                throw new InternalServerException();

            user.Code = OTP;
            //user.OTPExpiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["OTPExpiration"]));
            _userRepository.UpdateUser(user);
            return await _uow.SaveChangeAsync();
        }


        public async Task<bool> ResetPassword(ResetPasswordDTO dto)
        {
            var user = await _userRepository.UserFirstOrDefaultAsync<ApplicationDbUser>(x => x.PhoneNumber == dto.Phone);
            if (user == null)
                throw new BussinessRuleException("TheIdentityIdIsNotCorrect");

            var validToken = user.Code == dto.Otp ;
            if (!validToken)
                throw new BussinessRuleException("TokenIsNotValidOrExpired");

            var changetoken= await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, changetoken, dto.Password);
            if (!resetPasswordResult.Succeeded)
            {
                throw new BussinessRuleException("Error");
            }
           // _userRepository.UpdateUser(user);

            return await _uow.SaveChangeAsync();
        }
        public async Task<string> GetOTP(string userId)
        {
            if (Hosting.EnvironmentName == Environments.Production.ToString())
                return "TOU CAN'T ACCESS OTP";
            return (await _userRepository.UserFirstOrDefaultAsync<ApplicationDbUser>(x => x.Id == userId)).Code;
        }


        #region private

        private string GenerateToken(ApplicationDbUser user, bool rememberMe = true)
        {
            Claim[] claims = new[]
            {
                new Claim("userId", user.Id.ToString().Encrypt()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName.Encrypt()),
                new Claim(ClaimTypes.Role, user.UserType.Encrypt()),
            };

            SymmetricSecurityKey signatureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            SigningCredentials credentials = new SigningCredentials(signatureKey, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = rememberMe ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:ExpiryInMinutes"]))
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken accessToken = tokenHandler.CreateToken(accessTokenDescriptor);

            return tokenHandler.WriteToken(accessToken);

        }

        #endregion
    }
}
