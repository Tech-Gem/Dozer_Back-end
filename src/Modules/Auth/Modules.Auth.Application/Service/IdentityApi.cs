using ErrorOr;
using MediatR;
using Modules.Auth.Application.Users.Queries;
using Modules.Auth.Shared;
using Modules.Auth.Shared.DTOs;


namespace Modules.Auth.Application.Service;

public class IdentityApi : IIdentityApi
{
    private readonly ISender _mediator;

    public IdentityApi(ISender mediator)
    {
        _mediator = mediator;
    }

    public async Task<ErrorOr<UserDto>> GetUserById(string userId)
    {
        return await _mediator.Send(new GetUserByIdQuery(userId));
    }
    
}