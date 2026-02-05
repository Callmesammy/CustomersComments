using Application.Abstractions.Messaging;
using Application.Customer.Update;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class UpdateId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("customer/{id:guid}", async (
            Guid id,
            UpdateCustomerRequest request,
            ICommandHandler<UpdateCustomerCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateCustomerCommand(
                id,
                request.Name,
                request.Address,
                request.Comments);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }
}

public sealed record UpdateCustomerRequest(
    string Name,
    string Address,
    string Comments);
