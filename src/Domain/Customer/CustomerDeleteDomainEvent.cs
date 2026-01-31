using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Customer;

public sealed record CustomerDeleteDomainEvent(Guid CustomerId) : IDomainEvent;
