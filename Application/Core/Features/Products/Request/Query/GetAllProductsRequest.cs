using Application.Core.DTOs.EntitiesDto.Product;
using MediatR;

namespace Application.Core.Features.Products.Request.Query;

public class GetAllProductsRequest : IRequest<List<ProductDto>>
{
}