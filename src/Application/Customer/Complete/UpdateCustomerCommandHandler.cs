using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Update;

internal sealed class UpdateCustomerCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider dateTimeProvider,
    IUserContext userContext)
    : ICommandHandler<UpdateCustomerCommand>
{
    public async Task<Result> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        CustomerItem? customerItem = await context.Customers
            .SingleOrDefaultAsync(
                t => t.Id == command.CustomerItemId && t.UserId == userContext.UserId,
                cancellationToken);

        if (customerItem is null)
        {
            return Result.Failure(CustomerError.NotFound(command.CustomerItemId));
        }

        // Update the fields
        customerItem.Name = command.Name;
        customerItem.Address = command.Address;
        customerItem.Comments = command.Comments;
        customerItem.DateTime = dateTimeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
