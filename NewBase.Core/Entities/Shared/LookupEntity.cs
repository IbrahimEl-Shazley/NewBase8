using System.ComponentModel.DataAnnotations;

namespace NewBase.Core.Entities.Shared
{
    public abstract class LookupEntity : Entity
    {
        [MaxLength(100)]
        public virtual string NameAr { get; set; }

        [MaxLength(100)]
        public virtual string NameEn { get; set; }
    }
}
