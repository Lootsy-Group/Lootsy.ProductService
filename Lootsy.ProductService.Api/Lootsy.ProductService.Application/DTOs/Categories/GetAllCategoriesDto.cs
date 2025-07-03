namespace Lootsy.ProductService.Application.DTOs.Categories;

public record GetAllCategoriesDto(
    Guid id,
    string name,
    string imageurl);