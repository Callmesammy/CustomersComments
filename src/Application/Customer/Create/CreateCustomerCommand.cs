using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Domain.Customer;

namespace Application.Customer.Create;

internal sealed class CreateCustomerCommand : ICommand<Guid>
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public List<string> ProductBought { get; set; } = [];
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public DateTime IsCompleted { get; set; } 
    public StatusMode StatusMode { get; set; }

}
