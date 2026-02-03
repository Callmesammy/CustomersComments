using SharedKernel;

namespace Domain.Customer;

public sealed class CustomerItem : Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Comments { get; set; } 
    public string Address { get; set; } = string.Empty;    
    public List<string> ProductBought { get; set; } = [];
    public DateTime? DateTime { get; set; }
    public bool IsCompleted { get; set; }
    public StatusMode StatusMode { get; set; }
}
