using Application.Abstractions.Messaging;

namespace Application.Abstractions.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
