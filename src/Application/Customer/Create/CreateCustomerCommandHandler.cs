using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Create;

internal sealed class CreateCustomerHandler(IApplicationDbContext context, IUserContext userContext, IDateTimeProvider
    dateTimeProvider) : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
    if(userContext.UserId != command.UserId)
        {
            return Result.Failure<Guid>(UserErrors.Unauthorized());
        }

    User? user = await context.Users.AsNoTracking().SingleOrDefaultAsync
            (u => u.Id == command.UserId, cancellationToken);

        if(user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.UserId));
        }

        var customerItem = new CustomerItem
        {
            UserId = user.Id,
            Name = command.Name, 
            Comments = command.Comments,
            Address = command.Address,
            IsCompleted = false,
            DateTime = dateTimeProvider.UtcNow,
            ProductBought = command.ProductBought,
            StatusMode = command.StatusMode

        };

        customerItem.Raise(new CustomerCreatedDomainEvent(customerItem.Id));
        context.CustomerItems.Add(customerItem);
       await context.SaveChangesAsync(cancellationToken);

        return customerItem.Id;


    }


}
