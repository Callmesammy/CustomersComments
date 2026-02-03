
using Application.Abstractions.Messaging;
using Application.Customer.Create;
using Domain.Customer;
using Domain.Todos;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class Create : IEndpoint
{ 
    public class Request
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Comments { get; set; }
    public string Status { get; set; }
    public bool IsCompleted { get; set; }
    public List<string> ProductBought { get; set; } = [];
    public DateTime DateTime { get; set; }
    public int StatusMode { get; set; }
}


    public void MapEndpoint(IEndpointRouteBuilder app)
    {
    app.MapPost("cutomers", async (Request request,
        ICommandHandler<CreateCustomerCommand, Guid> handler,
        CancellationToken cancellationToken) => {
            var customer = new CreateCustomerCommand
            {
                UserId = request.UserId,
                Name = request.Name,
                Address = request.Address,
                Comments = request.Comments,
                ProductBought = request.ProductBought,
                DateTime = request.DateTime,
                StatusMode = (StatusMode)request.StatusMode
            };

            Result<Guid> result = await handler.Handle(customer, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();

    }
}

