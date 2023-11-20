using Application.Core.Exceptions;
using Application.Core.Features.Products.Request.Command;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Core.Features.Products.Handlers.Command;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
  


    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Check Validitor


        var productid = await _productRepository.GetByIdAsync(request.Id);
        if (productid == null) throw new NotFoundException(nameof(Product), request.Id);

        await _productRepository.DeleteAsync(productid.Id);
        return Unit.Value;
    }
}