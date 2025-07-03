using Lootsy.ProductService.Application.DTOs.Categories;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.QueryParameters;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Queries.Categories;

public record GetAllCategoriesQuery(
    CategoriesQueryParameter CategoriesQueryParameter
    ) : IRequest<Result<List<GetAllCategoriesDto>>>;
