using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewBase.Core.Entities.AdditionalTables;
using NewBase.Core.Entities.Chat;
using NewBase.Core.Entities.Copon;
using NewBase.Core.Entities.Follow;
using NewBase.Core.Entities.Rate;
using NewBase.Core.Entities.SettingTables;
using NewBase.Core.Entities;
using NewBase.Core.Entities.UserTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBase.Core.Entities.Enum;
using NewBase.Core.Entities.NOTIFIC;

namespace NewBase.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RateProvider> RateProvider { get; set; }
        //public DbSet<RateService> RateService { get; set; }
        public DbSet<LogExption> LogExption { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<DeviceId> DeviceIds { get; set; }
        public DbSet<NotifyUser> NotifyUsers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Copon> Copon { get; set; }
        public DbSet<CoponUsed> CoponUsed { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<QuestionsClient> QuestionsClient { get; set; }
        public DbSet<QuestionProvider> QuestionProvider { get; set; }
        //public DbSet<Favourite> Favourites { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }

        public DbSet<ConnectUser> ConnectUser { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Messages> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<HistoryNotify> HistoryNotify { get; set; }
        public DbSet<UserFollowers> UserFollowers { get; set; }
        //public DbSet<ProviderFollowers> ProviderFollowers { get; set; }

        /// <summary>
        /// Section IntroductorySite
        /// </summary>
        public DbSet<IntroSetting> IntroSettings { get; set; }
        public DbSet<IntroContactUs> IntroContactUs { get; set; }
        public DbSet<CustomerOpinion> CustomerOpinions { get; set; }
        public DbSet<AppImg> AppImgs { get; set; }
        public DbSet<Advantage> Advantages { get; set; }


        //public DbSet<Country> Countries { get; set; }
        //public DbSet<Governorate> Governorates { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Regoin> Regoins { get; set; }


        public DbSet<HomeMessages> HomeMessages { get; set; }

        #region notif
        public DbSet<NotificationCategory> NotificationCategory { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }
        public DbSet<NotificationQueue> NotificationQueue { get; set; }
        public DbSet<NotificationQueue> NotificationTemplate { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Country>().HasQueryFilter(c => !c.IsDeleted);
            //builder.Entity<Governorate>().HasQueryFilter(c => !c.IsDeleted);
            //builder.Entity<City>().HasQueryFilter(c => !c.IsDeleted);
            //builder.Entity<Regoin>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<ContactUs>().HasQueryFilter(c => !c.IsDeleted);
            builder.Entity<Copon>().HasQueryFilter(c => !c.IsDeleted);

            //builder.Seed();

            builder.Entity<ApplicationDbUser>()
            .HasMany(c => c.Sender)
            .WithOne(o => o.Sender)
            .HasForeignKey(o => o.SenderId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ApplicationDbUser>()
                       .HasMany(c => c.Receiver)
                       .WithOne(o => o.Receiver)
                       .HasForeignKey(o => o.ReceiverId)
                       .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ApplicationDbUser>()
                    .HasMany(c => c.Orders)
                    .WithOne(o => o.User)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<ApplicationDbUser>()
                    .HasMany(c => c.UserFollowersP)
                    .WithOne(o => o.Users)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationDbUser>()
                    .HasMany(c => c.UserFollowersU)
                    .WithOne(o => o.Providers)
                    .HasForeignKey(o => o.ProviderId)
                    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationDbUser>()
            //        .HasMany(c => c.RateProviderP)
            //        .WithOne(o => o.Client)
            //        .HasForeignKey(o => o.UserId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<ApplicationDbUser>()
            //        .HasMany(c => c.RateClientP)
            //        .WithOne(o => o.Provider)
            //        .HasForeignKey(o => o.ProviderId)
            //        .OnDelete(DeleteBehavior.NoAction);


        }

    }

}
