using System;
using AIH.ERP.Analytic.Domain.Enums;

namespace AIH.ERP.Analytic.Domain.Configurations
{
    public interface IEntity
    {
        public RecordStatus Status { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}
