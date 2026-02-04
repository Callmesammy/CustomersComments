using Application.Abstractions.Messaging;

namespace Application.Customer.Get;

public sealed record GetCustomerQuery(Guid UserId) : IQuery<List<CustomerResponse>>;
