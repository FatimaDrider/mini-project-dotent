using Application.Core.DTOs.EntitiesDto.Product;
using Application.Core.Features.Products.Request.Query;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Products.Handlers.Query;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.ListAllAsyFnc();
        var res = _mapper.Map<List<ProductDto>>(products);
        return res;
    }
}