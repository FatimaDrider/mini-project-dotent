using Application.Core.Exceptions;
using Application.Core.Features.Catergories.Request.Command;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Core.Features.Catergories.Handlers.Command;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICatergoryRepository _catergoryRepository;
    private readonly IMapper _mapper;
    public DeleteCategoryCommandHandler(ICatergoryRepository catergoryRepository, IMapper mapper)
    {
        _catergoryRepository = catergoryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        //Get the category by id
        var oldCategory = await _catergoryRepository.GetByIdAsync(request.Id);
        if (oldCategory == null)
            throw new NotFoundException(nameof(Category), request.Id);

        // Delete the category
        await _catergoryRepository.DeleteAsync(oldCategory.Id);
        return Unit.Value;
    }
}