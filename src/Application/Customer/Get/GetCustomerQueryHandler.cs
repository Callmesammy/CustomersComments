using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Get;

internal sealed class GetCustomerQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetCustomerQuery, List<CustomerResponse>>
{
    public async Task<Result<List<CustomerResponse>>> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
    {
        if (query.UserId != userContext.UserId)
        {
            return Result.Failure<List<CustomerResponse>>(UserErrors.Unauthorized());
        }

        List<CustomerResponse> customer = await context.Customers
            .Where(customer => customer.UserId == query.UserId)
            .Select(customerItem => new CustomerResponse
            {
                Id = customerItem.Id,
                UserId = customerItem.UserId,
                Name = customerItem.Name,
                Address = customerItem.Address,
                Comments = customerItem.Comments,
                ProductBought = customerItem.ProductBought,
                IsCompleted = customerItem.IsCompleted,
                DateTime = customerItem.DateTime,
            })
            .ToListAsync(cancellationToken);

        return customer;
    }
}
