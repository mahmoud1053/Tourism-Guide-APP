using Microsoft.EntityFrameworkCore;
using WebApplication2.Configurations;
using WebApplication2.Entities;


namespace WebApplication2.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new User_Configurations());
            modelBuilder.ApplyConfiguration(new Programs_Configurations());
            modelBuilder.ApplyConfiguration(new Program_Places_Configurations());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Program_Places> Program_Place { get; set; }
    }
}
