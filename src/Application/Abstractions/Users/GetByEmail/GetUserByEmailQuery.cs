using Application.Abstractions.Messaging;

namespace Application.Abstractions.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
