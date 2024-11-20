using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Core.Entities.Chat
{
    public class HomeMessagesDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserImg { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
    }
}
