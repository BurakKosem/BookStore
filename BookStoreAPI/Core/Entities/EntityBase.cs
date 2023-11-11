using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
        public virtual bool Status { get; set; } = true;
        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
