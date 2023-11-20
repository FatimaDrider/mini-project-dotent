using Application.Core.DTOs.EntitiesDto.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.MappingProfiles;

public class ProductMappingProfiles : Profile
{
    public ProductMappingProfiles()
    {
        CreateMap<ProductDto, Product>();
    }
}