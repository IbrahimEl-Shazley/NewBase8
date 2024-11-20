using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NewBase.Core.Helpers.Sql;

namespace NewBase.Core.Entities.Shared
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }

        //[ForeignKey(nameof(CreatedById))]
        public virtual long? CreatedById { get; set; }
        //public virtual User CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }

        public virtual long? UpdatedById { get; set; }
        public virtual DateTime? UpdatedOn { get; set; }

        public virtual bool IsDeleted { get; set; }
        public virtual long? DeletedById { get; set; }
        public virtual DateTime? DeletedOn { get; set; }


        public virtual T AddPredefinedColumns<T>(T entity, long? userId)
        {
            PredefinedCoulmnsHelper.Add(entity, userId);
            return entity;
        }

        public virtual T UpdatePredefinedColumns<T>(T entity, long? userId)
        {
            PredefinedCoulmnsHelper.Update(entity, userId);
            return entity;
        }
    }
}
