using Application.Core.DTOs.EntitiesDto.Product;
using MediatR;

namespace Application.Core.Features.Products.Request.Query;

public class GetProductDetailsRequest : IRequest<ProductDto>
{
    public int Id { get; set; }
}