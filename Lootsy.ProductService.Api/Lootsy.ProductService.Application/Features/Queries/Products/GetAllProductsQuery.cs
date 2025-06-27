using Lootsy.ProductService.Application.DTOs.Products;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.QueryParamets;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Queries.Products;

public record GetAllProductsQuery(
    ProductsQueryParameter ProductsQueryParameter
    ) : IRequest<Result<List<GetAllProductsDto>>>;
