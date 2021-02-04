using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Enums;

namespace AIH.ERP.Analytic.Domain.Configurations
{
    public class Entity : IEntity
    {
        public RecordStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Entity()
        {
            Status = RecordStatus.Active;
        }
    }
}
