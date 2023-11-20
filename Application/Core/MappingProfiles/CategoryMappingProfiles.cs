using Application.Core.DTOs.EntitiesDto.Category;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.MappingProfiles;

public class CategoryMappingProfiles : Profile
{
    public CategoryMappingProfiles()
    {
        CreateMap<CategoryDto, Category>();
    }
}