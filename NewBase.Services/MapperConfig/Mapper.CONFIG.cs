using AutoMapper;
//using NewBase.Core.Entities.Schema.CONFIG;
using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.CONFIG;
using NewBase.Service.Interfaces.General;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapConfig(ICurrentUserService currentUserService)
        {
            //CreateMap<SystemConfigurationCategory, SystemConfigurationCategoryDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<SystemConfigurationCreateDTO, SystemConfiguration>();
            //CreateMap<SystemConfiguration, SystemConfigurationDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();
        }
    }
}
