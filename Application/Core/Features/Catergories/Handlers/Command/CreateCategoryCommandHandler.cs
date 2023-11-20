using Application.Core.DTOs.EntitiesDto.Category.Validitors;
using Application.Core.Features.Catergories.Request.Command;
using Application.Responses;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using MediatR;

namespace Application.Core.Features.Catergories.Handlers.Command;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandReponse>
{
    
    
    private readonly ICatergoryRepository _catergoryRepository;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(ICatergoryRepository catergoryRepository, IMapper mapper)
    {
        _catergoryRepository = catergoryRepository;
        _mapper = mapper;
    }
    public async Task<BaseCommandReponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Check Validitor
        var response = new BaseCommandReponse();
        var validator = new CategoryValiditor();
        
        
        
        
        var validitorResult = await validator.ValidateAsync(request.CategoryDto);
        if (validitorResult.IsValid == false)
        {
            response.Success = false;
            response.Errors = validitorResult.Errors.Select(x => x.ErrorMessage).ToList();
            response.Message = "Failed to create category";
        }

        var category = _mapper.Map<Category>(request.CategoryDto);
        await _catergoryRepository.CreateAsync(category);
        response.Success = true;
        response.Message = "Category created successfully";
        response.Id = request.CategoryDto.Id;

        return response;
    }
}