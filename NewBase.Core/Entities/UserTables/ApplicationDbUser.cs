using Microsoft.AspNetCore.Identity;
using NewBase.Core.Entities.AdditionalTables;
using NewBase.Core.Entities.Chat;
using NewBase.Core.Entities.Follow;
using NewBase.Core.Entities.Rate;
using NewBase.Core.Entities.SettingTables;
using NewBase.Core.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Core.Entities.UserTables
{
    public partial class ApplicationDbUser : IdentityUser
    {
        public ApplicationDbUser()
        {
            ContactUs = new HashSet<ContactUs>();
            NotifyClient = new HashSet<NotifyUser>();
            DeviceId = new HashSet<DeviceId>();
            Sender = new HashSet<Messages>();
            Receiver = new HashSet<Messages>();
            ConnectUser = new HashSet<ConnectUser>();
            HistoryNotify = new HashSet<HistoryNotify>();
            Orders = new HashSet<Order>();
            OrdersP = new HashSet<Order>();


            // HashSet UserFollowers
            UserFollowersU = new HashSet<UserFollowers>();
            UserFollowersP = new HashSet<UserFollowers>();

        }


        //add props 
        public string UserType { get; set; }  // As string Or Enum
        public bool IsApprovedByAdmin { get; set; }
        public string User_Name { get; set; }
        public string ProjectName { get; set; }
        //public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool ActiveCode { get; set; }
        public string Code { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Location { get; set; }
        public string ImgProfile { get; set; }
        public DateTime CreationDate { get; set; }

        //Relation

        //ContactUs >> user  m>> o
        public virtual ICollection<ContactUs> ContactUs { get; set; }

        //DevieId >> user  m>> o
        public virtual ICollection<DeviceId> DeviceId { get; set; }
        //notifyclient >> user  m>> o
        public virtual ICollection<NotifyUser> NotifyClient { get; set; }
        //notifyDelegt >> user m>> o
        //public virtual ICollection<NotifyDelegt> NotifyDelegt { get; set; }


        // Rate Provider
        [InverseProperty(nameof(NewBase.Core.Entities.Rate.RateProvider.Client))]
        public virtual ICollection<RateProvider> RateClientP { get; set; }
        [InverseProperty(nameof(NewBase.Core.Entities.Rate.RateProvider.Provider))]
        public virtual ICollection<RateProvider> RateProviderP { get; set; }

        // Orders
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> OrdersP { get; set; }

        [InverseProperty(nameof(Follow.UserFollowers.Users))]
        public virtual ICollection<UserFollowers> UserFollowersU { get; set; }
        [InverseProperty(nameof(Follow.UserFollowers.Providers))]
        public virtual ICollection<UserFollowers> UserFollowersP { get; set; }


        // Message
        public virtual ICollection<Messages> Sender { get; set; }
        public virtual ICollection<Messages> Receiver { get; set; }

        public virtual ICollection<ConnectUser> ConnectUser { get; set; }


        // History Notifications
        public virtual ICollection<HistoryNotify> HistoryNotify { get; set; }





    }
}
