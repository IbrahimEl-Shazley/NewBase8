using AutoMapper;
using NewBase.Service.Interfaces.General;
//using NewBase.Core.Entities.Schema.CORE;
using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.CORE;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapCore(ICurrentUserService currentUserService)
        {
            //CreateMap<BrandRequest, BrandRequestDTO>();
            //CreateMap<BrandRequestCreateDTO, BrandRequest>();

            //CreateMap<BrandRequestName, BrandRequestNameDTO>();
            //CreateMap<BrandRequestNameCreateDTO, BrandRequestName>();

            //CreateMap<BrandRequestActionLog, BrandRequestActionLogDTO>()
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.DescriptionAr : src.DescriptionEn));
        }
    }
}
