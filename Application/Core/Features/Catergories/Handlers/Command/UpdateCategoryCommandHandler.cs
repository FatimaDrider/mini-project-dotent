using Application.Core.DTOs.EntitiesDto.Category.Validitors;
using Application.Core.Exceptions;
using Application.Core.Features.Catergories.Request.Command;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Catergories.Handlers.Command;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCatergoryCommand, Unit>
{
    private readonly ICatergoryRepository _catergoryRepository;
    private readonly IMapper _mapper;
    public UpdateCategoryCommandHandler(ICatergoryRepository catergoryRepository, IMapper mapper)
    {
        _catergoryRepository = catergoryRepository;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<Unit> Handle(UpdateCatergoryCommand request, CancellationToken cancellationToken)
    {
        // Check Validitor
        var validator = new CategoryValiditor();
        var validitorResult = await validator.ValidateAsync(request.CategoryDto);
        if (validitorResult.IsValid == false)
            throw new ValidationException(validitorResult);

        var oldCategory = await _catergoryRepository.GetByIdAsync(request.Id);
        var res = _mapper.Map(request.CategoryDto, oldCategory);
        await _catergoryRepository.UpdateAsync(res);
        return Unit.Value;
    }
}