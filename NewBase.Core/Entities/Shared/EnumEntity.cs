﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewBase.Core.Entities.Shared
{
    public abstract class EnumEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [MaxLength(50)]
        public virtual string Code { get; set; }

        [MaxLength(50)]
        public virtual string NameAr { get; set; }

        [MaxLength(50)]
        public virtual string NameEn { get; set; }
    }
}