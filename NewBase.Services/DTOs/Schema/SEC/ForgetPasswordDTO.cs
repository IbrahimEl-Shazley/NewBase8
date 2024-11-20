using FluentValidation;
using Microsoft.Extensions.Localization;
using NewBase.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Services.DTOs.Schema.SEC
{
    public class ForgetPasswordDTO
    {
        public string Phone { get; set; }
        public string Email { get; set; }    
        public NotificationTypeEnum VerificationType { get; set; } = NotificationTypeEnum.Email;


    }
}