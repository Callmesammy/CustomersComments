using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Domain.Todos;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Delete;

internal sealed class DeleteCustomerCommandHandler(IApplicationDbContext context, IUserContext userContext)
    : ICommandHandler<DeleteCustomerCommand>
{
    public async Task<Result> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        CustomerItem? customerItem = await context.Customers
            .SingleOrDefaultAsync(t => t.Id == command.CustomerItemId && t.UserId == userContext.UserId, cancellationToken);

        if (customerItem is null)
        {
            return Result.Failure(TodoItemErrors.NotFound(command.CustomerItemId));
        }

        context.Customers.Remove(customerItem);

        customerItem.Raise(new TodoItemDeletedDomainEvent(customerItem.Id));

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
