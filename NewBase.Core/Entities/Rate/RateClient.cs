using NewBase.Core.Entities.UserTables;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBase.Core.Entities.Rate
{
    public class RateClient
    {
        [Key]
        public int Id { get; set; }

        public string ProviderId { get; set; }

        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; } = 0;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser Client { get; set; }

        [ForeignKey(nameof(ProviderId))]
        public virtual ApplicationDbUser Deleget { get; set; }
    }
}
