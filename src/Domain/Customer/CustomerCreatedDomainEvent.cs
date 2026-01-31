using SharedKernel;

namespace Domain.Customer;

public sealed record CustomerCreatedDomainEvent (Guid CustomerId) : IDomainEvent;
