using FluentValidation;
using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Validators;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("The username is required.")
            .MaximumLength(50).WithMessage("The username cannot exceed 50 characters.")
            .EmailAddress().WithMessage("The username must be a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("The password is required")
            .MinimumLength(6).WithMessage("The password must be at least 6 characters")
            .MaximumLength(32).WithMessage("The password cannot exceed 32 characters");
    }
}