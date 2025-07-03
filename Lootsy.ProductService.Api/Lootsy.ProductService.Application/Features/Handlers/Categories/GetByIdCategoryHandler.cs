using Lootsy.ProductService.Application.DTOs.Categories;
using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Queries.Categories;
using Lootsy.ProductService.Domain.Exceptions;
using Lootsy.ProductService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lootsy.ProductService.Application.Features.Handlers.Categories;

internal sealed class GetByIdCategoryHandler : IRequestHandler<GetCategoryQuery, Result<CategoryDto>>
{
    public readonly IApplicationDbContext _context;

    public GetByIdCategoryHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Result<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var category = await _context.Categories
            .Where(p => p.Id == request.CategoryId)
            .Select(p => new CategoryDto
                (
                    p.Id,
                    p.Name,
                    p.Description ?? "",
                    p.ImageUrl ?? ""
                ))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Category doesn't exist");

        return Result<CategoryDto>.Success(category);
    }
}
