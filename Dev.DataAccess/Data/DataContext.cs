using Microsoft.EntityFrameworkCore;
using Dev.Common.Models;

namespace Dev.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Depense> Depenses { get; set; }
        public DbSet<SuiviDepense> SuiviDepenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurer la relation entre SuiviDepense et Depense
            modelBuilder.Entity<SuiviDepense>()
                .HasOne(p => p.Depense)
                .WithMany(pc => pc.SuiviDepenses)
                .HasForeignKey(p => p.DepenseId);

        }
    }
}