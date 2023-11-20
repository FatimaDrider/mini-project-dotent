using Domain.Common.Entities;

namespace Application.Core.DTOs.EntitiesDto.Category;

public class CategoryDto : BaseDto<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}