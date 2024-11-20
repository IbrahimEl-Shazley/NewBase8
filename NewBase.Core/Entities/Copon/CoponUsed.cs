﻿using System.ComponentModel.DataAnnotations;

namespace NewBase.Core.Entities.Copon
{
    public class CoponUsed
    {
        [Key]
        public int Id { get; set; }
        public int CoponId { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
    }
}
