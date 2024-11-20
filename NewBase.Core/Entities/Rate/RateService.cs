using System;
using System.ComponentModel.DataAnnotations;

namespace NewBase.Core.Entities.Rate
{
    public class RateService
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; } = 0;

    }
}
