using Lootsy.ProductService.Application.DTOs.Products;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Queries.Products;
using Lootsy.ProductService.Domain.Exceptions;
using Lootsy.ProductService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lootsy.ProductService.Application.Features.Handlers.Products;

internal sealed class GetByIdProductHandler : IRequestHandler<GetProductQuery, Result<ProductDto>>
{
    public readonly IApplicationDbContext _context;

    public GetByIdProductHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var product = await _context.Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductDto
                (
                    p.Id,
                    p.SellerId,
                    p.Name,
                    p.Price,
                    p.ImageUrl,
                    p.Status,
                    p.Details.Description,
                    p.Details.ImageUrls,
                    p.CategoryId
                ))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Product doesn't exist");

        return Result<ProductDto>.Success(product);
    }
}
