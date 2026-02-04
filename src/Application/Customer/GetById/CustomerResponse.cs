namespace Application.Customer.GetById;

public sealed class CustomerResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Comments { get; set; }
    public DateTime? DateTime { get; set; }
    public List<string> ProductBought { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
