using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public ProductConfig()
    {
      // Configuration for Product entity can be added here if needed
    }

    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.HasKey(p => p.ProductId);
      builder.Property(p => p.ProductName)
        .IsRequired()
        .HasMaxLength(100);
      builder.Property(p => p.Price)
        .IsRequired();
      builder.HasData(
        new Product() { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 17_000 },
        new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 1_000 },
        new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 500 },
        new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 7_000 },
        new Product() { ProductId = 5, CategoryId = 2, ProductName = "Deck", Price = 1_500 },
        new Product() { ProductId = 6, CategoryId = 1, ProductName = "History OF Human", Price = 1_000 },
        new Product() { ProductId = 7, CategoryId = 1, ProductName = "Tüfek Mikrop ve Çelik", Price = 2_000 }
      );
    }
  }
}