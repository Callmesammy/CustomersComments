using Application.Abstractions.Messaging;

namespace Application.Customer.Update;

public sealed record UpdateCustomerCommand(
    Guid CustomerItemId,
    string Name,
    string Address,
    string Comments) : ICommand;
