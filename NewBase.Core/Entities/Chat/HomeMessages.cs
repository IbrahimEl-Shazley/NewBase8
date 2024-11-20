using NewBase.Core.Entities.UserTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Core.Entities.Chat
{
    public class HomeMessages
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public DateTime DateSend { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }
    }
}
