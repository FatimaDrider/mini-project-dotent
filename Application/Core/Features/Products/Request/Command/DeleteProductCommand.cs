using Application.Core.DTOs.EntitiesDto.Product;
using MediatR;

namespace Application.Core.Features.Products.Request.Command;

public class DeleteProductCommand : IRequest<Unit>
{
    public ProductDto ProductDto { get; set; }
    public int Id { get; set; }
}