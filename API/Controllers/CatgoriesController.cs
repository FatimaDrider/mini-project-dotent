using Application.Core.DTOs.EntitiesDto.Category;
using Application.Core.Features.Catergories.Handlers.Query;
using Application.Core.Features.Catergories.Request.Command;
using Application.Core.Features.Catergories.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CatgoriesController: ControllerBase
{
    private readonly IMediator _mediator;

    public CatgoriesController(IMediator mediator)
    {
        _mediator = mediator;

        
    }
    [HttpGet("get-all-categories")]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetAllCategoryRequest());
        return Ok(result);
        
    }
    [HttpGet("get-category-by-id/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryDetailRequest());
        return Ok(result);
    }
    [HttpPost("create-category")]
    public async Task<IActionResult> Post([FromBody]CategoryDto categoryDto)
    {
       var command = new  CreateCategoryCommand{CategoryDto = categoryDto};
       var result = await _mediator.Send(command);
       return Ok(result);
       
       
    }
 
    
}