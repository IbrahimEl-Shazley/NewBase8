using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Enums;
using NewBase.Service.Interfaces.General;
using NewBase.Services.DTOs.Schema.SEC;
using NewBase.Services.Implementations.General;
using NewBase.Services.Interfaces.General;

namespace NewBase.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly ICurrentUserService _currentUserService;


        public AuthController(IAuthService authService, ICurrentUserService currentUserService)
        {
            _authService = authService;
            _currentUserService = currentUserService;
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDTO)
        {
            return _OK(await _authService.Login(userLoginDTO));
        }

        [AllowAnonymous]
        [HttpPost("ProviderRegisteration")]
        public async Task<IActionResult> ProviderRegisteration([FromForm] UserRegisterDTO userDTO)
        {
            return _OK(await _authService.Register(userDTO, Enum.GetName(typeof(UserType), UserType.Provider)), "UserRegisteredSuccessfully");
        }

        [AllowAnonymous]
        [HttpPost("ClientRegisteration")]
        public async Task<IActionResult> ClientRegisteration([FromForm] UserRegisterDTO userDTO)
        {
            return _OK(await _authService.Register(userDTO, Enum.GetName(typeof(UserType), UserType.Client)), "UserRegisteredSuccessfully");
        }


        [HttpPost("ActivateUser")]
        public async Task<IActionResult> ActivateUser([FromForm] UserVerifyDTO verifyDTO)
        {
            return _OK(await _authService.ActivateUser(UserId, verifyDTO), "UserVerifiedSuccessfully");
        }

        [HttpPost("ResendActivationOTP")]
        public async Task<IActionResult> ResendActivationOTP(NotificationTypeEnum verificationMethod = NotificationTypeEnum.Email)
        {
            return _OK(await _authService.ResendActivationOTP(UserId, verificationMethod), "NotificationSendSuccesfullyToVerificationMethod");
        }

        [AllowAnonymous]
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDTO forgetPasswordDTO)
        {
            return _OK(await _authService.ForgetPassword(forgetPasswordDTO), "NotificationSendSuccesfullyToVerificationMethod");

        }
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            return _OK(await _authService.ResetPassword(dto), "PasswordResetedSuccessfully");
        }

        //for test
        [HttpGet("GetOTP")]
        public async Task<IActionResult> GetOTP()
        {
            return _OK(await _authService.GetOTP(UserId));
        }
    }
}
