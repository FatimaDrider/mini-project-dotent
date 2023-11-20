using FluentValidation;

namespace Application.Core.DTOs.EntitiesDto.Category.Validitors;

public class CategoryValiditor : AbstractValidator<CategoryDto>
{
    public CategoryValiditor()
    {
        RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("Name is required")
        .MaximumLength(50)
        .WithMessage("Name must not exceed 50 characters")
        .MinimumLength(3)
        .WithMessage("Name must be at least 3 characters");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Id is required");
    }
}