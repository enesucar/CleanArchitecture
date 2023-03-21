using Application.Features.Categories.Commands;
using FluentValidation;

namespace Application.Features.Categories.Validators
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(o => o.Name)
                .MaximumLength(250)
                .NotEmpty();
        }
    }
}
