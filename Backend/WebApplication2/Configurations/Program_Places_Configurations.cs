using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Entities;

namespace WebApplication2.Configurations
{
    public class Program_Places_Configurations : IEntityTypeConfiguration<Program_Places>
    {
        public void Configure(EntityTypeBuilder<Program_Places> builder)
        {
            // Composite primary key
            builder.HasKey(pp => new { pp.Program_Id, pp.Name });

            // Property configuration
            builder.Property(pp => pp.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Foreign key and relationship configuration
            builder.HasOne(pp => pp.Program)
                   .WithMany(p => p.ProgramPlaces)
                   .HasForeignKey(pp => pp.Program_Id)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
