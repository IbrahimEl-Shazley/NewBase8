using AutoMapper;
using NewBase.Service.Interfaces.General;
//using NewBase.Core.Entities.Schema.ENUM;
//using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.ENUM;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapEnums(ICurrentUserService currentUserService)
        {
            //CreateMap<RequestStatus, RequestStatusDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<BillType, BillTypeDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<PaymentMethod, PaymentMethodDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<NotificationType, NotificationTypeDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<NotificationCategory, NotificationCategoryDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();
        }
    }
}
