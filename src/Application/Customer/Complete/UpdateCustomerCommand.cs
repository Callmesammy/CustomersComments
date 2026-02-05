using Application.Abstractions.Messaging;

namespace Application.Customer.Complete;

public sealed record UpdateCustomerCommand(Guid CustomerItemId,
    string Name, string Comments, 
    string Address) : ICommand;
