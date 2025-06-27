using Lootsy.ProductService.Domain.Enums;

namespace Lootsy.ProductService.Application.DTOs.Products;

public record ProductDto(
    Guid Id,
    Guid SellerId,
    string Name,
    decimal Price,
    string ImageUrl,
    ProductStatus Status,
    string Description,
    List<string> ImageUrls,
    Guid CategoryId
    );
