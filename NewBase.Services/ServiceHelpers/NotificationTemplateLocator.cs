using NewBase.Core.Enums;
using NewBase.Services.ServiceHelpers.EmailTemplates;
using System;
using System.Collections.Generic;

namespace NewBase.Services.ServiceHelpers
{
    public static class NotificationTemplateLocator
    {
        public static readonly Dictionary<NotificationCategoryEnum, Type> Templates = new Dictionary<NotificationCategoryEnum, Type>
        {
            { NotificationCategoryEnum.ActivateAccount, typeof(ActivateAccountTemplate) },
            { NotificationCategoryEnum.ResetPassword, typeof(ResetPasswordTemplate) }
            //{ NotificationCategoryEnum.CreateBrandRequest, typeof(CreateBrandRequestTemplate) }
        };
    }
}
