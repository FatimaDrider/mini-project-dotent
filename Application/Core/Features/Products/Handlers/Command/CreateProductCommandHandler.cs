using Application.Core.DTOs.EntitiesDto.Product.Validators;
using Application.Core.Features.Products.Request.Command;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Core.Features.Products.Handlers.Command;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandReponse>
{
    private readonly IProductRepository _productRepository;
    private IMapper _mapper;
    
    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandReponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Check Validitor
        var response = new BaseCommandReponse();
        var validator = new ProductValidator(_productRepository);
        var validirorResult = await validator.ValidateAsync(request.ProductDto);
        if (validirorResult.IsValid == false)
        {
            response.Success = false;
            response.Errors = validirorResult.Errors.Select(x => x.ErrorMessage).ToList();
            response.Message = "Failed to create product";
        }

        var product = _mapper.Map<Product>(request.ProductDto);
        await _productRepository.CreateAsync(product);
        response.Success = true;
        response.Message = "Product created successfully";
        response.Id = request.ProductDto.Id;
        return response;
    }
}