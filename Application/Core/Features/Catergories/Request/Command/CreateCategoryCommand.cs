using Application.Core.DTOs.EntitiesDto.Category;
using Application.Responses;
using MediatR;

namespace Application.Core.Features.Catergories.Request.Command;

public class CreateCategoryCommand : IRequest<BaseCommandReponse>
{
    public CategoryDto? CategoryDto { get; set; }
}