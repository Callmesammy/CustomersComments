using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Customer.Create;

internal sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator(){
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.StatusMode).IsInEnum();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
        RuleFor(c => c.Address).NotEmpty().MaximumLength(400);
        RuleFor(c => c.DateTime).GreaterThanOrEqualTo(DateTime.Today).When(c => c.DateTime.HasValue);
        }
}
