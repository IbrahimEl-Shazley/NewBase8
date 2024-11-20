using NewBase.Core.Enums;
using NewBase.Core.Models;
using NewBase.Services.DTOs.Schema.SEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Services.Interfaces.General
{
    public interface IAuthService: IBaseService
    {
        Task<string> Login(UserLoginDto userLoginDTO);
        Task<UserInfo> Register(UserRegisterDTO userDTO,string UserType);

        Task<bool> ActivateUser(string userId, UserVerifyDTO dto);
        Task<bool> ResendActivationOTP(string userId, NotificationTypeEnum verificationMethod);

        Task<bool> ForgetPassword(ForgetPasswordDTO dto);
        Task<bool> ResetPassword(ResetPasswordDTO dto);

        Task<string> GetOTP(string userId);


    }
}
