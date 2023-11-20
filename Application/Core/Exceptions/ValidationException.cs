using FluentValidation.Results;

namespace Application.Core.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException(ValidationResult validationResult)
    {
        foreach (var err in validationResult.Errors) Errors.Add(err.ErrorMessage);
    }
    public List<string> Errors { get; set; }
}