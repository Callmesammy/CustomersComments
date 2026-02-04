using FluentValidation;

namespace Application.Customer.Complete;

internal sealed class CompleteCustomerCommandValidator : AbstractValidator<CompletedCustomerCommand>
{
    public CompleteCustomerCommandValidator()
    {
        RuleFor(c => c.CustomerItemId).NotEmpty();
    }
}
