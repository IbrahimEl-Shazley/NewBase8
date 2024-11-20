using System.ComponentModel;

namespace NewBase.Core.Enums
{
    public enum NotificationTypeEnum
    {
        [Description("رسالة نصية")]
        SMS = 1,

        [Description("بريد الكترونى")]
        Email = 2,

        [Description("كلاهما")]
        Both = 3,
    }
}
