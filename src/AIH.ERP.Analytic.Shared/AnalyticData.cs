using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.Shared
{
    public class AnalyticData
    {
        public int Year { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal ExpenseAmount { get; set; }

        public static List<AnalyticData> GetFakeDatas()
        {
            var rng = new Random();
            return new List<AnalyticData>()
            {
                new AnalyticData()
                {
                    Year = 2015,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                },
                new AnalyticData()
                {
                    Year = 2016,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                },
                new AnalyticData()
                {
                    Year = 2017,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                },
                new AnalyticData()
                {
                    Year = 2018,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                },
                new AnalyticData()
                {
                    Year = 2019,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                },
                new AnalyticData()
                {
                    Year = 2020,
                    ExpenseAmount = rng.Next(100, 500),
                    ProfitAmount = rng.Next(100, 500),
                }
            };
        }
    }
}
