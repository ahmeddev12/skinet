using System.Linq;
using System.Reflection;
using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach(var entitType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties=entitType.ClrType.GetProperties().Where(p=>p.PropertyType==typeof(decimal));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entitType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }

        }
    }
}