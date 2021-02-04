using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;

namespace AIH.ERP.Analytic.DataAccess.Repository.Companies
{
    public class ProfitRepository: Repository<Profit>, IProfitRepository
    {
        private protected ApplicationDbContext _context;
        public ProfitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
