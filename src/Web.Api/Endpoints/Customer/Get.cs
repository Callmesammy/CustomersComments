using Application.Abstractions.Messaging;
using Application.Customer.Get;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Customer;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("customer", async (
            Guid userId,
            IQueryHandler<GetCustomerQuery, List<CustomerResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetCustomerQuery(userId);

            Result<List<CustomerResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Customers)
        .RequireAuthorization();
    }
}
