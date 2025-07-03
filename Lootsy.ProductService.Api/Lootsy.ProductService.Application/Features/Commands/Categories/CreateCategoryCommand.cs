using Lootsy.ProductService.Application.Extensions;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Commands.Categories;

public record CreateCategoryCommand (
    string Name,
    string Description,
    string imageUrl
) : IRequest<Result<Guid>>;
