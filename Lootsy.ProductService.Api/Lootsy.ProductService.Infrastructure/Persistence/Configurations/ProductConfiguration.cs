using Lootsy.ProductService.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lootsy.ProductService.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(p => p.Price)
            .HasPrecision(18, 2);

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(255);

        builder.Property(p => p.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.SellerId)
            .IsRequired();

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Value Object: ProductDetails
        builder.OwnsOne(p => p.Details, pd =>
        {
            pd.Property(d => d.Description)
              .HasColumnName("Description")
              .HasMaxLength(1000);

            pd.Property(d => d.ImageUrls)
              .HasColumnName("ImageUrls")
              .HasConversion(
                  v => string.Join(";", v),
                  v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
              );
        });
    }
}
