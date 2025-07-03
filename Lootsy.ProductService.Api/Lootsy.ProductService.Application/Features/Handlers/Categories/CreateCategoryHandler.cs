using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Commands.Categories;
using Lootsy.ProductService.Domain.Aggregates;
using Lootsy.ProductService.Domain.Interfaces;
using MediatR;

namespace Lootsy.ProductService.Application.Features.Handlers.Categories;

internal sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;
    public CreateCategoryHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var category = new Category(
            request.Name,
            request.Description,
            request.imageUrl);

        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(category.Id);
    }
}
