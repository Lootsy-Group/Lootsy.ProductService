using Lootsy.ProductService.Domain.Enums;

namespace Lootsy.ProductService.Application.DTOs.Products;

public record GetAllProductsDto(
    Guid Id,
    Guid SellerId,
    string Name,
    decimal Price,
    string ImageUrl,
    ProductStatus Status,
    Guid CategoryId
    );
