using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Customer;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Customer.Update;

public sealed class UpdateCustomerHandler(IApplicationDbContext context) : ICommandHandler<UpdateCustomerCommand>
{
    public async Task<Result> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        CustomerItem? customerItem = await context.Customers.SingleOrDefaultAsync(
            t => t.Id == command.CustomerItemId, cancellationToken); 
        if(customerItem is null)
        {
            return Result.Failure(UserErrors.NotFound(command.CustomerItemId));
        }
        customerItem.Name = command.Name;
        customerItem.Address = command.Address;
        customerItem.Comments = command.Comments;
        
        context.Customers.Update(customerItem);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();

    }
}
