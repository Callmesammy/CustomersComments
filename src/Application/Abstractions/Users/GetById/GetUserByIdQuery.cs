using Application.Abstractions.Messaging;

namespace Application.Abstractions.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
