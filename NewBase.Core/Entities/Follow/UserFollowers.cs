using NewBase.Core.Entities.UserTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Core.Entities.Follow
{
    public class UserFollowers
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProviderId { get; set; }


        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationDbUser.UserFollowersU))]
        public virtual ApplicationDbUser Users { get; set; }


        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(ApplicationDbUser.UserFollowersP))]
        public virtual ApplicationDbUser Providers { get; set; }



    }
}
