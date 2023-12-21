using MediatR;
using Modules.Auth.Application.Mappings;
using Modules.Auth.Application.Service;
using Modules.Auth.Shared.DTOs;
using ErrorOr;

namespace Modules.Auth.Application.Users.Queries.Handlers;


internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserDto>>
{
    private readonly IIdentityService _identityService;

    public GetUserByIdQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ErrorOr<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _identityService.GetUserById(request.UserId);
        return user.Match<ErrorOr<UserDto>>(
            value => UserMapper.UserToUserDto(value),
            errors => errors
        );
    }
}