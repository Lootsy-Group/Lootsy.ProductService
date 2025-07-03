using Lootsy.ProductService.Application.DTOs.Categories;
using Lootsy.ProductService.Application.DTOs.Products;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Queries.Categories;
using Lootsy.ProductService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lootsy.ProductService.Application.Features.Handlers.Categories;

internal sealed class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<GetAllCategoriesDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoriesHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Result<List<GetAllCategoriesDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var categories = await FilterProductsAsync(request, cancellationToken);

        return Result<List<GetAllCategoriesDto>>.Success(categories);
    }
    public async Task<List<GetAllCategoriesDto>> FilterProductsAsync(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Categories.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.CategoriesQueryParameter.Name))
            query = query.Where(c => c.Name.Contains(request.CategoriesQueryParameter.Name));

        var categories = await query
            .Select(c => new GetAllCategoriesDto(
                c.Id,
                c.Name,
                c.ImageUrl))
            .ToListAsync(cancellationToken);

        return categories;
    }
}
