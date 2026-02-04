using Application.Abstractions.Messaging;
using Application.Customer.GetById;
using Application.Todos.GetById;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("customer/{id:guid}", async (
            Guid id,
            IQueryHandler<GetCustomerByIdQuery, CustomerResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new GetCustomerByIdQuery(id);

            Result<CustomerResponse> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }
}
