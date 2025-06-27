using Lootsy.ProductService.Domain.Common;
using Lootsy.ProductService.Domain.Enums;
using Lootsy.ProductService.Domain.ValueObjects;

namespace Lootsy.ProductService.Domain.Aggregates;

public class Product : AuditableEntity
{
    public Guid Id { get; set; }
    public Guid SellerId { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
    public ProductStatus Status { get; set; }
    public Guid CategoryId { get; set; }
    public ProductDetails Details { get; set; } = default!;

    public Product() { }

    public Product(
        Guid sellerId, string name, decimal price, string imageUrl, ProductStatus status, Guid categoryId)
    {
        Id = Guid.NewGuid();
        SellerId = sellerId;
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        Status = status;
        CategoryId = categoryId;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetDetails(ProductDetails details)
    {
        Details = details;
    }
}
