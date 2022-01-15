using API.Domain.Helpers;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Carboidratos" },
                new Category { Id = 2, Name = "Produtos de Limpeza" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 1,
                    Name = "Arroz",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Detergente",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 2,
                }
            );

        }
    }
}
