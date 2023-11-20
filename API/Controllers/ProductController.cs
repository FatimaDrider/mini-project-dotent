using Application.Core.DTOs.EntitiesDto.Product;
using Application.Core.Features.Catergories.Request.Query;
using Application.Core.Features.Products.Request.Command;
using Application.Core.Features.Products.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductController: ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("get-all-products")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllProductsRequest());
        return Ok(result);
        
    }
    [HttpGet("get-product-by-id/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryDetailRequest{Id = id});
        return Ok(result);
    }
    [HttpPost("create-product")]
    public async Task<IActionResult> Post(ProductDto productDto)
    {
        var result = await _mediator.Send(new CreateProductCommand { ProductDto = productDto });
        return Ok(result);
    }
    
}