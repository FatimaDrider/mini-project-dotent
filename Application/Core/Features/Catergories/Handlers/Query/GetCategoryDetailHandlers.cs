using Application.Core.DTOs.EntitiesDto.Category;
using Application.Core.Features.Catergories.Request.Query;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Catergories.Handlers.Query;

public class GetCategoryDetailHandlers : IRequestHandler<GetCategoryDetailRequest, CategoryDto>
{
    private readonly ICatergoryRepository _catergoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryDetailHandlers(ICatergoryRepository catergoryRepository, IMapper mapper)
    {
        _catergoryRepository = catergoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
    {
        var category = await _catergoryRepository.GetByIdAsync(request.Id);
        var res = _mapper.Map<CategoryDto>(category);
        return res;
    }
}