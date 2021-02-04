using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;

namespace AIH.ERP.Analytic.DataAccess.Repository.Companies
{
    public class ExpenseRepository:Repository<Expense>,IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
