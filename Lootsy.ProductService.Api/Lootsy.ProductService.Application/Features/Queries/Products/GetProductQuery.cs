using Lootsy.ProductService.Application.DTOs.Products;
using Lootsy.ProductService.Application.Extensions;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Queries.Products;

public record GetProductQuery(
    Guid ProductId
    ) : IRequest<Result<ProductDto>>;
