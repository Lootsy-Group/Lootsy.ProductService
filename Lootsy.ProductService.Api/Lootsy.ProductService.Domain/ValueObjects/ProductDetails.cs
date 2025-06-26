namespace Lootsy.ProductService.Domain.ValueObjects;

public class ProductDetails
{
    public string Description { get; set; } = default!;
    public List<string> ImageUrls { get; set; } = new();
}
