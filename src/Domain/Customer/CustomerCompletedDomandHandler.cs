using SharedKernel;

namespace Domain.Customer;

public sealed record CustomerCompletedDomandHandler(Guid CustomerId) : IDomainEvent;

