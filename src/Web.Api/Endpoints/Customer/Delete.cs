using Application.Abstractions.Messaging;
using Application.Customer.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("customer/{id:guid}", async (
            Guid id,
            ICommandHandler<DeleteCustomerCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteCustomerCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }
}
