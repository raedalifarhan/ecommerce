using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // // لو اننا وضعنا حقل الراتب ديسيمال فأنة لا يقبل الترتيب فيلزم هذا الكود
            // if (Database.ProviderName == "")
            // {
            //     foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //     {
            //         var properties = entityType.ClrType.GetProperties()
            //             .Where(p => p.PropertyType == typeof(decimal));

            //         foreach (var property in properties)
            //         {
            //             modelBuilder.Entity(entityType.Name)
            //                 .Property(property.Name)
            //                 .HasConversion<double>();
            //         }
            //     }
            // }
        }
    }

}