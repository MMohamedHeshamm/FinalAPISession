using FinalAPISession.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAPISession.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<Department> departments { get; set; }

        public DbSet<Device> devices { get; set; }

        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Patient> patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
