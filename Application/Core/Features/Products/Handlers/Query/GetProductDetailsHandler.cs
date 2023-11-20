using Application.Core.DTOs.EntitiesDto.Product;
using Application.Core.Features.Products.Request.Query;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Products.Handlers.Query;

public class GetProductDetailsHandler : IRequestHandler<GetProductDetailsRequest, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public GetProductDetailsHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        var res = _mapper.Map<ProductDto>(product);
        return res;
    }
}