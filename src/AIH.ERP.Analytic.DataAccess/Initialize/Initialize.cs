using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.DataAccess.Initialize.Data;
using Microsoft.EntityFrameworkCore;

namespace AIH.ERP.Analytic.DataAccess.Initialize
{
    public static  class Initialize
    {
        public static async Task SeedAsync(ApplicationDbContext context,string fileDir)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
            FakeDatas fakeDatas=new FakeDatas(fileDir);
            var companies=fakeDatas.CreateCompanies();
            await context.Companies.AddRangeAsync(companies);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
