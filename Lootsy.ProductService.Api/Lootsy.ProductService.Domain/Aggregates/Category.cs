using Lootsy.ProductService.Domain.Common;

namespace Lootsy.ProductService.Domain.Aggregates;

public class Category : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public Category() { }

    public Category(string name, string? description = null, string? imageUrl = null)
    {
        Id = Guid.NewGuid();
        Name = name ;
        Description = description;
        ImageUrl = imageUrl;
        CreatedAt = DateTime.UtcNow;
    }
}
