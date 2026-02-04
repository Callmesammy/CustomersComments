using Application.Abstractions.Messaging;

namespace Application.Todos.Complete;

public sealed record CompletedCustomerCommand(Guid TodoItemId) : ICommand;
