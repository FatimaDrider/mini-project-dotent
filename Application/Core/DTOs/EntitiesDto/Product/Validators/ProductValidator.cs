using Domain.Contracts;
using FluentValidation;

namespace Application.Core.DTOs.EntitiesDto.Product.Validators;

public class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator(IProductRepository _productRepository)
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("{PropertyName} is required! ")
        .MaximumLength(50)
        .WithMessage("PropertyName} must not exceed 50 characters")
        .MinimumLength(3)
        .WithMessage("{PropertyName} must be at least 3 characters");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Price).NotEmpty()
        .GreaterThan(0)
        .WithMessage("{PropertyName} greater than {ComparisonValue}");

        RuleFor(x => x.CategoryId)
        .GreaterThan(0)
        .WithMessage("{PropertyName} greater than {ComparisonValue}")
        .MustAsync(async (id, token) =>
        {
            var categoryidExisit = await _productRepository.Exisit(id);
            return !categoryidExisit;
        })
        .WithMessage("{PropertyName} does not exisit ?");
    }
}