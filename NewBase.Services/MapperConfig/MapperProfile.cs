using AutoMapper;
using Microsoft.Extensions.Options;
using NewBase.Core.DTOs;
using NewBase.Core.Entities;
using NewBase.Core.Entities.UserTables;
using NewBase.Service.Interfaces.General;
using NewBase.Services.DTOs.Schema.SEC;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public MapperProfile() { 
        }  
        public MapperProfile(ICurrentUserService currentUserService)
        {
            MapSecurity(currentUserService);
            MapLookups(currentUserService);
            MapEnums(currentUserService);
            MapCore(currentUserService);
            MapConfig(currentUserService);
            MapAcc(currentUserService);
            MapNotific(currentUserService);


            #region File
            //CreateMap<CloudinaryDotNet.Actions.ImageUploadResult, FileDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SecureUrl.Segments[5]))
            //    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.SecureUrl.AbsoluteUri))
            //    .ReverseMap();
            #endregion
        }
    }
}
