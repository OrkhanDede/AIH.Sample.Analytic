using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;
using AIH.ERP.Analytic.Shared;

namespace AIH.ERP.Analytic.Application.Services
{
    public  interface ICompanyService
    {
        Task<List<Company>> GetAllCompanyAsync();
        Task<List<Company>> GetCompanies(CompanyFilterModel filterRequest);
        Task<List<AnalyticData>> GetAnalyticDataAsync(int companyId,int yearFrom,int yearTo);
        Task AddProfitToCompanyAsync(Profit profit);
        Task AddExpenseToCompanyAsync(Expense expense);
        Task<bool> HasCompanyByIdAsync(int companyId);
    }
}
