namespace Lootsy.ProductService.Application.DTOs.Categories;

public record CategoryDto (
    Guid Id,
    string Name,
    string Description,
    string ImageUrl
    );