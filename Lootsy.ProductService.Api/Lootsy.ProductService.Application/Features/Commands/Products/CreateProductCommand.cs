using Lootsy.ProductService.Application.Extensions;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Commands.Product;

public record CreateProductCommand(
    Guid SellerId,
    string Name,
    decimal Price,
    string ImageUrl,
    string Description,
    List<string> ImageUrls,
    Guid CategoryId
) : IRequest<Result<Guid>>;