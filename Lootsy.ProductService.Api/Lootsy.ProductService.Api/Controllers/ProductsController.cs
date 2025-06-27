using Lootsy.ProductService.Application.Features.Commands.Product;
using Lootsy.ProductService.Application.Features.Queries.Products;
using Lootsy.ProductService.Application.QueryParamets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lootsy.ProductService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Get All Products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductsQueryParameter filter)
    {
        var products = await _mediator.Send(new GetAllProductsQuery(filter));
        return Ok(products);
    }

    /// <summary>
    /// Get Product with Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] GetProductQuery getProductQuery)
    {
        var product = await _mediator.Send(getProductQuery);

        return Ok(product);
    }

    /// <summary>
    /// Create Product
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}
