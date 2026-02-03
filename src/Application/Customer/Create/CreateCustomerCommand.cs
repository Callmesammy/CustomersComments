using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Domain.Customer;

namespace Application.Customer.Create;

public sealed class CreateCustomerCommand : ICommand<Guid>
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Comments { get; set; } 
    public List<string> ProductBought { get; set; } = [];
    public DateTime? DateTime { get; set; }
    public bool IsCompleted { get; set; } 
    public StatusMode StatusMode { get; set; }

}
