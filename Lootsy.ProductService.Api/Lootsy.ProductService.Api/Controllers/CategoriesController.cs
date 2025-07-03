using Lootsy.ProductService.Application.Features.Commands.Categories;
using Lootsy.ProductService.Application.Features.Queries.Categories;
using Lootsy.ProductService.Application.QueryParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lootsy.ProductService.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Get All Products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CategoriesQueryParameter filter)
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery(filter));
        return Ok(categories);
    }

    /// <summary>
    /// Get Product with Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    [HttpGet("{CategoryId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] GetCategoryQuery getCategoryQuery)
    {
        var category = await _mediator.Send(getCategoryQuery);

        return Ok(category);
    }

    /// <summary>
    /// Create Product
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }
}
