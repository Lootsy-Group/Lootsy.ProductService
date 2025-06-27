namespace Lootsy.ProductService.Application.QueryParamets;

public record ProductsQueryParameter(
    string? Name,
    Guid? CategoryId,
    decimal? MinPrice,
    decimal? MaxPrice
    );
