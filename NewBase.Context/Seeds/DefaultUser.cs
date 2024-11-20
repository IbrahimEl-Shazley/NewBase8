 
using Microsoft.AspNetCore.Identity;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Context.Seeds
{
    public static class DefaultUser
    {
        public static List<ApplicationDbUser> IdentityBasicUserList()
        {
            var hasher = new PasswordHasher<ApplicationDbUser>();

            return new List<ApplicationDbUser>()
            {
                new ApplicationDbUser
                {
                    // ادمن لوحه التحكم
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "aait@aait.sa",
                    Email = "aait@aait.sa",
                    User_Name = "aait@aait.sa",
                    
                    UserType =UserType.Admin.ToString(),
                    //ActiveCode = true,
                    //PublishDate = DateTime.Now,
                    //IsActive = true,
                    //ImgProfile = "https://upload.wikimedia.org/wikipedia/commons/7/72/Default-welcomer.png",
                    NormalizedEmail = "aait@aait.sa",
                    NormalizedUserName = "Aait@Aait.sa",


                },
                new ApplicationDbUser
                {
                    // يوزر لسرفس
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    UserName = "Api@aait.sa",
                    Email = "Api@aait.sa",
                    User_Name = "Api@aait.sa",
                   
                     UserType = UserType.Client.ToString(),
                    //ActiveCode = true,
                    //PublishDate = DateTime.Now,
                    //IsActive = true,
                    //ImgProfile = "https://upload.wikimedia.org/wikipedia/commons/7/72/Default-welcomer.png",
                    NormalizedEmail = "Api@aait.sa",
                    NormalizedUserName = "Api@Aait.sa",
                },
            };
        }
    }
}
