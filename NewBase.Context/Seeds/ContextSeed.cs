using Microsoft.AspNetCore.Identity;
using NewBase.Core.Entities.UserTables;
using NewBase.Core.Enums;
using NewBase.Core.Helpers;

namespace NewBase.Context.Seeds
{
    public static class ContextSeed
    {

        public static async Task Seed(UserManager<ApplicationDbUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            await CreateBasicSetting(applicationDbContext);
            await CreateBasicSocialMedia(applicationDbContext);
            await CreateBasicQustionClient(applicationDbContext);
            await CreateBasicQustionProvider(applicationDbContext);
            await CreateRoles(roleManager);
            await CreateBasicUsers(userManager);
        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (IdentityRole role in DefaultRoles.IdentityRoleList())
            {
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task CreateBasicUsers(UserManager<ApplicationDbUser> userManager)
        {
            try
            {
                foreach (ApplicationDbUser user in DefaultUser.IdentityBasicUserList())
                {
                    var userFound = await userManager.FindByEmailAsync(user.Email);
                    if (userFound == null)
                    {
                        await userManager.CreateAsync(user, "123456");
                        if (user.UserType == Enum.GetName(typeof(UserType), UserType.SuperAdmin))
                            await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                        else
                            await userManager.AddToRoleAsync(user, Roles.Mobile.ToString());
                    }
                }
            }           
             catch (Exception ex)
            {

                throw;
            }


        }



        private static async Task CreateBasicSetting(ApplicationDbContext applicationDbContext)
        {
            //if (!await applicationDbContext.Settings.AnyAsync())
            //{
            //    try
            //    {
            //        applicationDbContext.Database.OpenConnection();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Settings ON;");
            //        await applicationDbContext.Settings.AddAsync(DefaultSettings.BasicSettingAsync());
            //        int dd = await applicationDbContext.SaveChangesAsync();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Settings OFF;");
            //    }
            //    finally
            //    {
            //        applicationDbContext.Database.CloseConnection();
            //    }
            //}
        }

        private static async Task CreateBasicSocialMedia(ApplicationDbContext applicationDbContext)
        {
            //    if (!await applicationDbContext.SocialMedias.AnyAsync())
            //    {
            //        try
            //        {
            //            applicationDbContext.Database.OpenConnection();
            //            await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SocialMedias ON;");
            //            await applicationDbContext.SocialMedias.AddRangeAsync(DefaultSocialMedia.BasicSocialMediaAsync());
            //            int dd = await applicationDbContext.SaveChangesAsync();
            //            await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT SocialMedias OFF;");
            //        }
            //        finally
            //        {
            //            applicationDbContext.Database.CloseConnection();
            //        }
            //    }
        }

        private static async Task CreateBasicQustionClient(ApplicationDbContext applicationDbContext)
        {
            //if (!await applicationDbContext.QuestionsClient.AnyAsync())
            //{
            //    try
            //    {
            //        applicationDbContext.Database.OpenConnection();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT QuestionsClient ON;");
            //        await applicationDbContext.QuestionsClient.AddRangeAsync(DefaultClientPopularQuestion.BasicQustionClientAsync());
            //        int dd = await applicationDbContext.SaveChangesAsync();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT QuestionsClient OFF;");
            //    }
            //    finally
            //    {
            //        applicationDbContext.Database.CloseConnection();
            //    }
            //}
        }

        private static async Task CreateBasicQustionProvider(ApplicationDbContext applicationDbContext)
        {
            //if (!await applicationDbContext.QuestionProvider.AnyAsync())
            //{
            //    try
            //    {
            //        applicationDbContext.Database.OpenConnection();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT QuestionProvider ON;");
            //        await applicationDbContext.QuestionProvider.AddRangeAsync(DefaultProviderPopularQuestion.BasicQustionProviderAsync());
            //        int dd = await applicationDbContext.SaveChangesAsync();
            //        await applicationDbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT QuestionProvider OFF;");
            //    }
            //    finally
            //    {
            //        applicationDbContext.Database.CloseConnection();
            //    }
            //}
        }


    }
}
