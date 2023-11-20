using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            // DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity<int>>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedData = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedData = DateTime.Now;
                        break;
                }
            return base.SaveChangesAsync(cancellationToken);
        }
        
    }
}