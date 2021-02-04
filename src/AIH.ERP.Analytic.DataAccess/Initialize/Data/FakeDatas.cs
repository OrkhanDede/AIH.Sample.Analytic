using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;
using AIH.ERP.Analytic.Domain.Enums;
using Newtonsoft.Json;

namespace AIH.ERP.Analytic.DataAccess.Initialize.Data
{
    public class FakeDatas
    {
        private readonly List<Profit> _profits;
        private readonly List<Expense> _expenses;

        public FakeDatas(string fileDir)
        {
            _expenses = ReadExpenseFromJsonFile(fileDir);
            _profits = ReadProfitFromJsonFile(fileDir);
        }

        private List<Expense> ReadExpenseFromJsonFile(string fileDir)
        {
            var jsonFilePath = Path.Combine(fileDir, "MOCK_DATA_EXPENSE_1000.json");

            var jsonText = File.ReadAllText(jsonFilePath);
            var expense = JsonConvert.DeserializeObject<List<Expense>>(jsonText);
            return expense;


        }
        private List<Profit> ReadProfitFromJsonFile(string fileDir)
        {
            var jsonFilePath = Path.Combine(fileDir, "MOCK_DATA_PROFIT_1000.json");
            var jsonText = File.ReadAllText(jsonFilePath);
            var profits = JsonConvert.DeserializeObject<List<Profit>>(jsonText);
            return profits;

        }
        public List<Company> CreateCompanies()
        {
            return new List<Company>()
            {
                new Company()
                {
                    Title = "AzerCosmos",
                    Status = RecordStatus.Active,
                    Profits = GetProfitByRange(0,250),
                    Expenses = GetExpenseByRange(0,250)
                },
                new Company()
                {
                    Title = "AZAL",
                    Status = RecordStatus.Active,
                    Profits = GetProfitByRange(250,250),
                    Expenses = GetExpenseByRange(250,250)
                },
                new Company()
                {
                    Title = "Azer turk bank",
                    Status = RecordStatus.Active,
                    Profits = GetProfitByRange(500,250),
                    Expenses = GetExpenseByRange(500,250)
                },
                new Company()
                {
                    Title = "Yeni bir sirket daha",
                    Status = RecordStatus.Active,
                    Profits = GetProfitByRange(750,250),
                    Expenses = GetExpenseByRange(750,250)
                }
            };
        }
        private List<Profit> GetProfitByRange(int index, int count)
        {
            var rangedProfit = _profits.GetRange(index, count);
            var resultList = new List<Profit>();
            foreach (var profit in rangedProfit)
            {
                profit.Status = RecordStatus.Active;
                resultList.Add(profit);
            }
            return resultList;
        }

        private List<Expense> GetExpenseByRange(int index, int count)
        {
            var rangedExpense = _expenses.GetRange(index, count);
            var resultList = new List<Expense>();
            foreach (var expense in rangedExpense)
            {
                expense.Status = RecordStatus.Active;
                resultList.Add(expense);
            }
            return resultList;
        }
    }
}
