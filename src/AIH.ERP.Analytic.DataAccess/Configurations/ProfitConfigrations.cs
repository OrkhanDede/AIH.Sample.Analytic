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
    public class ProfitConfigrations : IEntityTypeConfiguration<Profit>
    {
        public void Configure(EntityTypeBuilder<Profit> builder)
        {

            builder.ToTable("Profits", SchemaNames.AIH_ERP);

            builder.HasOne(e => e.Company)
                .WithMany(e => e.Profits)
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
