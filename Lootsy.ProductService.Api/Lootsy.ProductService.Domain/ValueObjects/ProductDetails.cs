namespace Lootsy.ProductService.Domain.ValueObjects;

public class ProductDetails
{
    public string Description { get; set; } = default!;
    public List<string> ImageUrls { get; set; } = new();

    public ProductDetails() { }

    public ProductDetails(string description, List<string> imageUrls)
    {
        Description = description;
        ImageUrls = imageUrls ?? new List<string>();
    }
}
