using FluentValidation;
using LibraryCatalogAPI.Models.DTOs.Create;

namespace LibraryCatalogAPI.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("The book title is required.")
            .MaximumLength(150).WithMessage("The title cannot exceed 150 characters.");

        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("An ISBN is required.")
            .Matches(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$").WithMessage("The ISBN format is invalid.");

        RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("An AuthorId is required.");
    }
}