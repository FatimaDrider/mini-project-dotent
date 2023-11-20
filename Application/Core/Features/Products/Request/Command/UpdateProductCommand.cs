using Application.Core.DTOs.EntitiesDto.Product;
using MediatR;

namespace Application.Core.Features.Products.Request.Command;

public class UpdateProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public ProductDto ProductDto { get; set; }
}