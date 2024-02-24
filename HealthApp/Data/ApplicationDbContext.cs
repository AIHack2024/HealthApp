using HealthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AutoimmuneDiseaseEntry> Patients { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
