using Application.Core.DTOs.EntitiesDto.Category;
using MediatR;

namespace Application.Core.Features.Catergories.Request.Query;

public class GetAllCategoryRequest : IRequest<List<CategoryDto>>
{
}