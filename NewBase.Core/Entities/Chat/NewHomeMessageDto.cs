using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Core.Entities.Chat
{
    public class NewHomeMessageDto
    {
        public int id { get; set; }
        public string message { get; set; }
        public string userId { get; set; }
        public string img { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
    }
}
