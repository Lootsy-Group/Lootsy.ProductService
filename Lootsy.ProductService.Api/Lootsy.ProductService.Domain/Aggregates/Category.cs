using Lootsy.ProductService.Domain.Common;

namespace Lootsy.ProductService.Domain.Aggregates;

public class Category : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
