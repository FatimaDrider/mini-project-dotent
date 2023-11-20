using Application.Core.DTOs.EntitiesDto.Category;
using MediatR;

namespace Application.Core.Features.Catergories.Request.Command;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public CategoryDto CategoryDto { get; set; }
}