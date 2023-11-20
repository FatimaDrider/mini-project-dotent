using Application.Core.DTOs.EntitiesDto.Category;
using MediatR;

namespace Application.Core.Features.Catergories.Request.Query;

public class GetCategoryDetailRequest : IRequest<CategoryDto>
{
    public int Id { get; set; }
}