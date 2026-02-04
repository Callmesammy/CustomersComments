using Application.Abstractions.Messaging;

namespace Application.Customer.Complete;

public sealed record CompletedCustomerCommand(Guid CustomerItemId) : ICommand;
