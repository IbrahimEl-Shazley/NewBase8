using NewBase.Service.Interfaces.General;
using Microsoft.AspNetCore.Http;
using System.Linq;
using NewBase.Core.Enums;
using NewBase.Core.Helpers.Security;
using System.Security.Claims;
using NewBase.Core.ExtensionsMethods;
using System.Globalization;
using NewBase.Services;

namespace NewBase.Service.Implementation.General
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public string UserId => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //public string UserId => _httpContextAccessor.HttpContext?.User.Identity.Name;
 

        public Language Language
        {
            get
            {
                if (ProjectTypeService.IsApi == false)
                {
                    var lang = CultureInfo.CurrentCulture.Name.StartsWith("ar") ? "ar" : "en";
                    var x = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
                    return lang.ToUpper() == "AR" ? Language.Ar : Language.En;
                }
                else
                {
                    _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Language", out var Lang).ToString();
                    var lang = Lang.FirstOrDefault().ToUpper();
                    return lang == "AR" ? Language.Ar : Language.En;
                }

            }
        }

        //public string UserId
        //{
        //    get
        //    {
        //        if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        //            return null;
        //        return (JwtManager.GetClaimValue(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity, "userId".Decrypt() ?? "");
        //    }
        //}

        public bool IsArabic => Language == Language.Ar;



    }
}
