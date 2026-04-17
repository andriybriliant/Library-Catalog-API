using FluentValidation;
using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Validators;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("The username is required.")
            .MaximumLength(50).WithMessage("The username cannot exceed 50 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("The password is required.")
            .MaximumLength(32).WithMessage("The password cannot exceed 32 characters.");

    }
}