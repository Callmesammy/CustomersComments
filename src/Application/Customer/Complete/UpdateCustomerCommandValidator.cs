using FluentValidation;

namespace Application.Customer.Update;

internal sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.CustomerItemId).NotEmpty();

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(500).WithMessage("Address must not exceed 500 characters");

        RuleFor(c => c.Comments)
            .MaximumLength(1000).WithMessage("Comments must not exceed 1000 characters");
    }
}
