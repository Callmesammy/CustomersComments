using FluentValidation;

namespace Application.Customer.Delete;

internal sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(c => c.CustomerItemId).NotEmpty();
    }
}
