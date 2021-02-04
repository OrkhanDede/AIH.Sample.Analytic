using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIH.ERP.Analytic.DataAccess.Configurations
{
    public class ExpenseConfigurations : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {

            builder.ToTable("Expenses", SchemaNames.AIH_ERP);

            builder.HasOne(e => e.Company)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
