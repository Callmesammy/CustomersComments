using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Customer;

public static class CustomerError
{
    public static Error AlreadyCompleted(Guid customerId) => Error.Problem(
        "CustomerItem.AlreadyCompleted",
        $"the user with id = {customerId} already exist"
        );
    public static Error NotFound(Guid customerId) => Error.Problem(
        "CustomerItem.NotFound",
        $"The user with id = {customerId} is not found"
        );
}
