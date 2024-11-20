using NewBase.Core.Entities.UserTables;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBase.Core.Entities.SettingTables
{
    public class HistoryNotify
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }
    }
}
