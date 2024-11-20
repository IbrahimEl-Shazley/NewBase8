using System.ComponentModel;

namespace NewBase.Core.Enums
{
    public enum NotificationCategoryEnum
    {
        [Description("تفعيل الحساب")]
        ActivateAccount = 1,

        [Description("إعادة تعيين كلمة المرور")]
        ResetPassword = 2,

        //[Description("انشاء طلب خدمة سمها")]
        //CreateBrandRequest = 3,
    }
}
