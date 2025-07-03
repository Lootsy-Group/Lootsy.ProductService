using Lootsy.ProductService.Application.DTOs.Categories;
using Lootsy.ProductService.Application.Extensions;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Queries.Categories;

public record GetCategoryQuery(
    Guid CategoryId
    ) : IRequest<Result<CategoryDto>>;
