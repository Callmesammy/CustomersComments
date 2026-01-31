
namespace Web.Api.Endpoints.Customer;

internal sealed class Create : IEndpoint
    public class Request
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public bool IsCompleted { get; set; }
    public List<string> ProductBought { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}

{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }
}

