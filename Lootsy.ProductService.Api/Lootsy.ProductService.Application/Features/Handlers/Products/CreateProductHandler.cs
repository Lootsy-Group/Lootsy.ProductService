using Lootsy.ProductService.Application.Extensions;
using Lootsy.ProductService.Application.Features.Commands.Product;
using Lootsy.ProductService.Domain.Aggregates;
using Lootsy.ProductService.Domain.Enums;
using Lootsy.ProductService.Domain.Exceptions;
using Lootsy.ProductService.Domain.Interfaces;
using Lootsy.ProductService.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lootsy.ProductService.Application.Features.Handlers.Products;

internal sealed class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateProductHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var existCategory = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
            ?? throw new EntityNotFoundException("Category doesn't exist!");

        var product = new Product(
            request.SellerId,
            request.Name,
            request.Price, 
            request.ImageUrl,
            ProductStatus.Available,
            request.CategoryId);

        product.SetDetails(new ProductDetails(
            request.Description,
            request.ImageUrls));

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(product.Id);
    }
}
