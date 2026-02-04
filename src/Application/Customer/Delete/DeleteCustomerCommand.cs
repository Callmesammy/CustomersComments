using Application.Abstractions.Messaging;

namespace Application.Customer.Delete;

public sealed record DeleteCustomerCommand(Guid CustomerItemId) : ICommand;
