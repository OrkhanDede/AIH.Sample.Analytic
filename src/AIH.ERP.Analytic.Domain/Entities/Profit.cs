using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Configurations;
using AIH.ERP.Analytic.Domain.Enums;

namespace AIH.ERP.Analytic.Domain.Entities
{
    public class Profit : IEntity
    {
        public long Id { get; set; }
        public DateTime DateOfProfit { get; set; }
        public decimal Money { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }



        public RecordStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
