using AutoMapper;
using NewBase.Service.Interfaces.General;
//using NewBase.Core.Entities.Schema.NOTIFIC;
//using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.NOTIFIC;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapNotific(ICurrentUserService currentUserService)
        {
            //CreateMap<NotificationQueueCreateDTO, NotificationQueue->();
            //CreateMap<NotificationQueue, NotificationQueueDTO>();
        }
    }
}
