using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Configurations;
using AIH.ERP.Analytic.Domain.Enums;

namespace AIH.ERP.Analytic.Domain.Entities
{
    public class Company : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public ICollection<Profit> Profits { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        

        public RecordStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Company()
        {
            Profits=new List<Profit>();
            Expenses = new List<Expense>();
        }
    }
}
