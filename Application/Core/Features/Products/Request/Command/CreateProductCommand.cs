using Application.Core.DTOs.EntitiesDto.Product;
using Application.Responses;
using MediatR;

namespace Application.Core.Features.Products.Request.Command;

public class CreateProductCommand : IRequest<BaseCommandReponse>
{
    public ProductDto ProductDto { get; set; }
}