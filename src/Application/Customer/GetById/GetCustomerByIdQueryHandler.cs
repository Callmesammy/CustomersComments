using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.GetById;

internal sealed class GetCustomerByIdQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>
{
    public async Task<Result<CustomerResponse>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        CustomerResponse? customerItem = await context.Customers
            .Where(customerItem => customerItem.Id == query.CustomerItemId && customerItem.UserId == userContext.UserId)
            .Select(customerItem => new CustomerResponse
            {
                Id = customerItem.Id,
                UserId = customerItem.UserId,
                Name = customerItem.Name,
                Comments = customerItem.Comments,
                Address = customerItem.Address,
                IsCompleted = customerItem.IsCompleted,
                DateTime = customerItem.DateTime,
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (customerItem is null)
        {
            return Result.Failure<CustomerResponse>(CustomerError.NotFound(query.CustomerItemId));
        }

        return customerItem;
    }
}
