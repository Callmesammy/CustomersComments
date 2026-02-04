using FluentValidation;

namespace Application.Todos.Complete;

internal sealed class CompleteTodoCommandValidator : AbstractValidator<CompletedCustomerCommand>
{
    public CompleteTodoCommandValidator()
    {
        RuleFor(c => c.TodoItemId).NotEmpty();
    }
}
