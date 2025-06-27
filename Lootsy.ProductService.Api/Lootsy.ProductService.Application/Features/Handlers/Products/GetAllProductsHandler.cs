using Lootsy.ProductService.Application.DTOs.Products;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Queries.Products;
using Lootsy.ProductService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lootsy.ProductService.Application.Features.Handlers.Products;

internal sealed class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<List<GetAllProductsDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetAllProductsHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result<List<GetAllProductsDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var products = await FilterProductsAsync(request, cancellationToken);

        return Result<List<GetAllProductsDto>>.Success(products);
    }

    public async Task<List<GetAllProductsDto>> FilterProductsAsync(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.ProductsQueryParameter.Name))
            query = query.Where(p => p.Name.Contains(request.ProductsQueryParameter.Name));

        if (request.ProductsQueryParameter.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == request.ProductsQueryParameter.CategoryId.Value);

        if (request.ProductsQueryParameter.MinPrice.HasValue)
            query = query.Where(p => p.Price >= request.ProductsQueryParameter.MinPrice.Value);

        if (request.ProductsQueryParameter.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= request.ProductsQueryParameter.MaxPrice.Value);

        var products = await query
            .Select(p => new GetAllProductsDto(
                p.Id,
                p.SellerId,
                p.Name,
                p.Price,
                p.ImageUrl,
                p.Status,
                p.CategoryId))
            .ToListAsync(cancellationToken);

        return products;
    }
}
