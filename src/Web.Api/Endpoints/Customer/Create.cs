using Application.Abstractions.Messaging;
using Application.Customer.Create;
using Domain.Customer;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Address { get; set; } 
        public DateTime? DateTime { get; set; }
        public List<string> ProductBought { get; set; } = [];
        public int StatusMode { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("customer", async (
            Request request,
            ICommandHandler<CreateCustomerCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {


            var command = new CreateCustomerCommand
            {
                UserId = request.UserId,
                Name = request.Name,
                Address = request.Address,
                Comments = request.Comments,
                DateTime = request.DateTime,
                ProductBought = request.ProductBought,
                StatusMode = (StatusMode)request.StatusMode
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }

}


