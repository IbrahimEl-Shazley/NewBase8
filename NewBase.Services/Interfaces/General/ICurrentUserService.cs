using NewBase.Core.Enums;

namespace NewBase.Service.Interfaces.General
{

    public interface ICurrentUserService 
    {
        string UserId { get; }
        Language Language { get; }
        bool IsArabic { get; }
    }
}
