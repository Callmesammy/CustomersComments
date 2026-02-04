using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Complete;

internal sealed class CompleteCustomerCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContext userContext)
    : ICommandHandler<CompletedCustomerCommand>
{
    public async Task<Result> Handle(CompletedCustomerCommand command, CancellationToken cancellationToken)
    {
        CustomerItem? customerItem = await context.Customers
            .SingleOrDefaultAsync(t => t.Id == command.CustomerItemId && t.UserId == userContext.UserId, cancellationToken);

        if (customerItem is null)
        {
            return Result.Failure(CustomerError.NotFound(command.CustomerItemId));
        }

        if (customerItem.IsCompleted)
        {
            return Result.Failure(CustomerError.AlreadyCompleted(command.CustomerItemId));
        }

        customerItem.IsCompleted = true;
        customerItem.DateTime = dateTimeProvider.UtcNow;

        customerItem.Raise(new CustomerCreatedDomainEvent(customerItem.Id));

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
