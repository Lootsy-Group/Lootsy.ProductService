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
}
