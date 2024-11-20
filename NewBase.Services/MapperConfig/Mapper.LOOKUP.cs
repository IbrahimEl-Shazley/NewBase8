using AutoMapper;
using NewBase.Core.Models.DTO;
using NewBase.Service.Interfaces.General;
//using NewBase.Core.Entities.Schema.LOOKUP;
//using NewBase.Data.Entities.Shared;
//using NewBase.Services.Interfaces.General;
//using NewBase.Services.DTOs.Schema.LOOKUP;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapLookups(ICurrentUserService currentUserService)
        {
            //CreateMap<LookupEntity, LookupDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<BrandTypeCreateDTO, BrandType>();
            //CreateMap<BrandType, BrandTypeDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<BrandSubTypeCreateDTO, BrandSubType>();
            //CreateMap<BrandSubType, BrandSubTypeDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<CountryCreateDTO, Country>();
            //CreateMap<Country, CountryDTO>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //   .ReverseMap();

            //CreateMap<StateCreateDTO, State>();
            //CreateMap<State, StateDTO>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //   .ReverseMap();


            //CreateMap<DialCodeCreateDTO, DialCode>();
            //CreateMap<DialCode, DialCodeDTO>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //   .ReverseMap();


            //CreateMap<NationalityeCreateDTO, Nationality>();
            //CreateMap<Nationality, NationalityDTO>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //   .ReverseMap();
        }
    }
}
