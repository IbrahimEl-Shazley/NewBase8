using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NewBase.Context;
using NewBase.Services.Interfaces.General;
using NewBase.Services.Implementations.General;
using NewBase.Core.Models;
using NewBase.Core.Entities.UserTables;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using NewBase.Service.Interfaces.General;
using NewBase.Service.Implementation.General;
using NewBase.Repositories.Interfaces;
using NewBase.Repositories.Implementations;
using NewBase.Core.Entities.Shared;
using NewBase.Core.Models.DTO;
using NewBase.Repositories.UnitOfWork;
using NewBase.Services.Implementation;
using NewBase.Services.Interfaces;
using NewBase.Services.Implementation.General;
using NewBase.Integration.Services.Abstraction;
using NewBase.Integration.Services.Implementation;
using NewBase.Services;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using NewBase.Services.MapperConfig;
//using NewBase.Services.Interfaces.Generic;

namespace NewBase.Helpers
{
    public static class ConfigureServices
    {
        public static void AddDbContextServices(this IServiceCollection services,IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("MsSqlConnectionString")));
        }


        public static void AddSingletonServices(this IServiceCollection services)
        {


        }

        public static void AddLocalizationServices(this IServiceCollection services)
        {
            //services.AddLocalization(options => options.ResourcesPath = "Resources");

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var supportedCultures = new[]
            //    {
            //            new CultureInfo("ar"),
            //            new CultureInfo("en")
            //    };

            //    options.DefaultRequestCulture = new RequestCulture(supportedCultures[1]);
            //    options.SupportedCultures = supportedCultures;
            //    options.SupportedUICultures = supportedCultures;
            //});



             
        }

        public static void TimeOutServices(this IServiceCollection services, IWebHostEnvironment Environment)
        {
            services.AddDataProtection()
                              .SetApplicationName($"my-app-{Environment.EnvironmentName}")
                              .PersistKeysToFileSystem(new DirectoryInfo($@"{Environment.ContentRootPath}\keys"));

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(300);
            });


        }

        public static void AddDefaultIdentityServices(this IServiceCollection services)
        {

            services.AddDefaultIdentity<ApplicationDbUser>(options =>
            {
                // Default Password settings.
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();
        }
        public static void AddJwtServices(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddAuthentication(options =>
            {
                //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = Configuration["Jwt:Site"],
                    ValidIssuer = Configuration["Jwt:Site"],

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                };
            });

        }
        public static void AddScopedServices(this IServiceCollection services)
        {
            //services.AddScoped<IHelper, Helper>();
            //services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUserRepository, UserRepository>();
            //  services.AddScoped<IValidator<UserRegisterDTO>, UserRegisterValidator>();

            // BASE DI
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IBaseRepository<Entity>, BaseRepository<Entity>>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IBaseService<Entity, DTO, DTO, DTO>, BaseService<Entity, DTO, DTO,DTO>>();



        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            // GENERAL SERVICES DI
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            // ENTITY DI
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            // Notif DI
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ISMSService, SMSService>();

         }

        public static void SetEnvironment(this IServiceCollection services,IWebHostEnvironment environment)
        {

            Hosting.Environment = environment;

        }


        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //options.AddDefaultPolicy(
                //    builder =>
                //    {
                //        builder.WithOrigins("https://localhost:44306/")
                //        .AllowAnyHeader()
                //        .AllowAnyMethod()
                //        .AllowCredentials();
                //    });
                options.AddPolicy("NewBase", o =>
                {
                    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }



        //    public static void AddController(this IServiceCollection services)
        //    {
        //        services.AddControllers();
        //    }


        public static void addfluentvalidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
             .AddFluentValidationClientsideAdapters()
             .AddValidatorsFromAssembly(typeof(ServicesAssembly).Assembly);
        }   
        
        public static void addAutoMapper(this IServiceCollection services)
        {
           services.AddAutoMapper(new Action<IMapperConfigurationExpression>(cfg =>
            {
                cfg.AddProfile(new MapperProfile(new CurrentUserService(new HttpContextAccessor())));
            }));
        } 

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "NewBase.API", Version = "v1" });
                options.OperationFilter<SwaggerCustomHeaderAttribute>();
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Specify the authorization token.",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                    new string[] {}
                }});
            });
        }
    }
}
