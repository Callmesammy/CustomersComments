using Application.Abstractions.Messaging;

namespace Application.Abstractions.Users.Register;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<Guid>;
