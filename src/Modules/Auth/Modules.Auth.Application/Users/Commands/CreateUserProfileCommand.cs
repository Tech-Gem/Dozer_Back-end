using MediatR;
using Modules.Auth.Shared.DTOs;
using ErrorOr;

namespace Modules.Auth.Application.Users.Commands;

public record CreateUserProfileCommand(CreateUserProfileDto CreateUserProfileDto) : IRequest<ErrorOr<UserDto>>;
    


