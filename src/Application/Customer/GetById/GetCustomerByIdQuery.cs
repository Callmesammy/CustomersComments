using Application.Abstractions.Messaging;

namespace Application.Customer.GetById;

public sealed record GetCustomerByIdQuery(Guid CustomerItemId) : IQuery<CustomerResponse>;
