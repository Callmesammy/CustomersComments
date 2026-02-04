using Application.Abstractions.Messaging;
using Application.Todos.Complete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class Complete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("customer/{id:guid}/complete", async (
            Guid id,
            ICommandHandler<CompletedCustomerCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CompletedCustomerCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }
}
