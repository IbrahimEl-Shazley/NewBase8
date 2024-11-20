using AutoMapper;
//using NewBase.Core.Entities.Schema.SEC;
using NewBase.Core.ExtensionsMethods;
using NewBase.Services.DTOs.Schema.SEC;
using NewBase.Services.Interfaces.General;
using NewBase.Service.Interfaces.General;
using NewBase.Core.Entities.UserTables;

namespace NewBase.Services.MapperConfig
{
    public partial class MapperProfile : Profile
    {
        public void MapSecurity(ICurrentUserService currentUserService)
        {
            //CreateMap<User, UserDTO>()
            //   .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserInfo.FirstName))
            //   .ForPath(dest => dest.FatherName, opt => opt.MapFrom(src => src.UserInfo.FatherName))
            //   .ForPath(dest => dest.GrandFatherName, opt => opt.MapFrom(src => src.UserInfo.GrandFatherName))
            //   .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.UserInfo.LastName))
            //    .ReverseMap(); // for CreatedBy
            //CreateMap<UserLoginDto, User>().ReverseMap();

           // CreateMap<UserRegisterDTO, ApplicationDbUser>();
            CreateMap<ApplicationDbUser, UserInfo>();
        
        CreateMap<UserRegisterDTO, ApplicationDbUser>()
             .ForMember(dest => dest.DeviceId, opt => opt.Ignore());

            //CreateMap<UserRegisterMobileDTO, UserMobile>().ReverseMap();
            //CreateMap<UserRegisterAddressDTO, UserAddress>().ReverseMap();
            //CreateMap<User, UserProfileDto>()
            //   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString().Encrypt()))
            //   .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserInfo.FirstName))
            //   .ForMember(dest => dest.FatherName, opt => opt.MapFrom(src => src.UserInfo.FatherName))
            //   .ForMember(dest => dest.GrandFatherName, opt => opt.MapFrom(src => src.UserInfo.GrandFatherName))
            //   .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.UserInfo.LastName))
            //   .ForMember(dest => dest.UserMobiles, opt => opt.MapFrom(src => src.Mobiles))
            //   .ReverseMap();
            //CreateMap<UserMobile, UserProfileMobileDTO>().ReverseMap();

            //CreateMap<UserRole, UserRoleDTO>().ReverseMap();

            //CreateMap<PermissionCategory, PermissionCategoryDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();
            //CreateMap<PermissionCategory, PermissionCategoryCreateDTO>().ReverseMap();

            //CreateMap<Permission, PermissionDTO>()
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //   .ReverseMap();
            //CreateMap<Permission, PermissionCreateDTO>().ReverseMap();

            //CreateMap<Role, RoleCreateDto>().ReverseMap();
            //CreateMap<Role, RoleDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();

            //CreateMap<PermissionCategory, RolePermissionCategoryDTO>()
            // .ForMember(dest => dest.CategoryPermissions, opt => opt.MapFrom(src => src.Permissions))
            // .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            // .ReverseMap();
            //CreateMap<Permission, RoleCategoryPermissionDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => statlessSessionService.IsArabic ? src.NameAr : src.NameEn))
            //    .ReverseMap();
        }
    }
}
