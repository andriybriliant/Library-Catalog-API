using FluentValidation;
using LibraryCatalogAPI.Models.DTOs.Create;

namespace LibraryCatalogAPI.Validators;

public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
{
    public CreateAuthorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The author's name is required.")
            .MaximumLength(50).WithMessage("The author's name cannot exceed 50 characters.");
    }
}