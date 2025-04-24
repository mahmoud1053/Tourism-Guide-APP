using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Contracts;

namespace WebApplication2.Configurations
{
    internal class Programs_Configurations : IEntityTypeConfiguration<Programs>
    {
        public void Configure(EntityTypeBuilder<Programs> builder)
        {
            builder.HasKey(c => c.Program_Id);
            builder.Property(c => c.Program_Id).UseIdentityColumn(10, 10);
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
        }
    }
}
