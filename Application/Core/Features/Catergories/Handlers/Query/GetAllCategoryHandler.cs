using Application.Core.DTOs.EntitiesDto.Category;
using Application.Core.Features.Catergories.Request.Query;
using AutoMapper;
using Domain.Contracts;
using MediatR;

namespace Application.Core.Features.Catergories.Handlers.Query;

public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, List<CategoryDto>>
{
    private readonly ICatergoryRepository _catergoryRepository;
    private readonly IMapper _mapper;
    public GetAllCategoryHandler(ICatergoryRepository catergoryRepository, IMapper mapper)
    {
        _catergoryRepository = catergoryRepository;
        _mapper = mapper;
    }



    public async Task<List<CategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _catergoryRepository.ListAllAsyFnc();
        var res = _mapper.Map<List<CategoryDto>>(categories);
        return res;
    }
}