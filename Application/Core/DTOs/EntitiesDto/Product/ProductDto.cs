using Application.Core.DTOs.EntitiesDto.Category;
using Domain.Common.Entities;

namespace Application.Core.DTOs.EntitiesDto.Product;

public class ProductDto : BaseDto<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}