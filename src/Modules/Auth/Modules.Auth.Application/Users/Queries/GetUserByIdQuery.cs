using ErrorOr;
using MediatR;
using Modules.Auth.Shared.DTOs;

namespace Modules.Auth.Application.Users.Queries;

public sealed record GetUserByIdQuery(string UserId) : IRequest<ErrorOr<UserDto>>;

