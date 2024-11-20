using NewBase.Core.Enums;
using NewBase.Services.DTOs.General;
using System.Threading.Tasks;

namespace NewBase.Services.Interfaces.General
{
    public interface INotificationService : IBaseService
    {
        Task<bool> Send(Notification dto, NotificationTypeEnum verificationType);
        Task<bool> Send(Notification dto);
    }
}
