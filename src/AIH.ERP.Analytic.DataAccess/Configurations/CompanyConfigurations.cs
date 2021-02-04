using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIH.ERP.Analytic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIH.ERP.Analytic.DataAccess.Configurations
{
    public class CompanyConfigurations: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies", SchemaNames.AIH_ERP);

            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.Title).HasMaxLength(100);
            
            builder.HasMany(e => e.Expenses)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId);

            builder.HasMany(e => e.Profits)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
