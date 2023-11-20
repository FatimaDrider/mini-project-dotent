using Application.Core.DTOs.EntitiesDto.Product.Validators;
using Application.Core.Exceptions;
using Application.Core.Features.Products.Request.Command;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Products.Handlers.Command;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private IMapper _mapper;
    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
 

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Check Validitor
        var validator = new ProductValidator(_productRepository);
        var validirorResult = await validator.ValidateAsync(request.ProductDto);
        if (validirorResult.IsValid == false)
            throw new ValidationException(validirorResult);

        var oldProduct = await _productRepository.GetByIdAsync(request.Id);
        var res = _mapper.Map(request.ProductDto, oldProduct);
        await _productRepository.UpdateAsync(res);
        return Unit.Value;
    }
}