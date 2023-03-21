using Application.Features.Products.Commands;
using FluentValidation;

namespace Application.Features.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(o => o.Name)
                .MaximumLength(250)
                .NotEmpty();

            RuleFor(o => o.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(o => o.Quantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
