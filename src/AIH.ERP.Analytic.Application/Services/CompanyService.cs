using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.DataAccess;
using AIH.ERP.Analytic.DataAccess.Repository;
using AIH.ERP.Analytic.DataAccess.Repository.Companies;
using AIH.ERP.Analytic.Domain.Entities;
using AIH.ERP.Analytic.Shared;
using Microsoft.EntityFrameworkCore;

namespace AIH.ERP.Analytic.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        private readonly IExpenseRepository _expenseRepository;

        private readonly IProfitRepository _profitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IExpenseRepository expenseRepository, IProfitRepository profitRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _expenseRepository = expenseRepository;
            _profitRepository = profitRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await _companyRepository.GetAll().ToListAsync();
        }

        public async Task<bool> HasCompanyByIdAsync(int companyId)
        {
            return await _companyRepository.Table.AnyAsync(x => x.Id == companyId);
        }

        public async Task AddProfitToCompanyAsync(Profit profit)
        {
            await _profitRepository.AddAsync(profit);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddExpenseToCompanyAsync(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<List<AnalyticData>> GetAnalyticDataAsync(int companyId,
            int yearFrom, int yearTo)
        {

            var queryProfit = await
                _profitRepository.Table
                    .Where(p => p.DateOfProfit.Year >= yearFrom
                                && p.DateOfProfit.Year <= yearTo && p.CompanyId == companyId)

                    .GroupBy(p => p.DateOfProfit.Year)
                    .Select(p => new
                    {
                        year = p.Key,
                        Sum = p.Sum(s => s.Money)
                    }).ToListAsync();

            var queryExpense = await
                _expenseRepository.Table
                    .Where(p => p.DateOfExpense.Year >= yearFrom
                                && p.DateOfExpense.Year <= yearTo && p.CompanyId == companyId)

                    .GroupBy(p => p.DateOfExpense.Year)
                    .Select(p => new
                    {
                        year = p.Key,
                        Sum = p.Sum(s => s.Money)
                    }).ToListAsync();

            List<AnalyticData> result = new List<AnalyticData>();

            if (queryProfit.Count >= queryExpense.Count)
            {
                foreach (var profits in queryProfit)
                {
                    result.Add(new AnalyticData()
                    {
                        Year = profits.year,
                        ProfitAmount = profits.Sum,
                        ExpenseAmount = queryExpense.Where(x => x.year == profits.year).Select(x => x.Sum).FirstOrDefault()
                    });
                }
            }
            else
            {
                foreach (var expsense in queryExpense)
                {
                    result.Add(new AnalyticData()
                    {
                        Year = expsense.year,
                        ExpenseAmount = expsense.Sum,
                        ProfitAmount = queryProfit.Where(x => x.year == expsense.year).Select(x => x.Sum).FirstOrDefault()
                    });
                }
            }
            return result;
        }

        public async Task<List<Company>> GetCompanies(CompanyFilterModel filterRequest)
        {

            Expression<Func<Company, bool>> filterPredicate = c => true;
            if (filterRequest != null)
            {
                var isIdExist = filterRequest.Id != null;
                var isTitleExist = !string.IsNullOrEmpty(filterRequest.Title);

                filterPredicate = c =>
                    (!isIdExist || (c.Id == filterRequest.Id)) &&
                        (!isTitleExist || (c.Title == filterRequest.Title));
            }
            return await _companyRepository.FindBy(filterPredicate).ToListAsync();

        }
    }
}
