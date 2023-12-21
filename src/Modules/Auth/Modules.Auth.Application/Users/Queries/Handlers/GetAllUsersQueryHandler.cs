using Dozer.Shared.Models;
using MediatR;
using Modules.Auth.Application.Mappings;
using Modules.Auth.Application.Service;
using Modules.Auth.Shared.DTOs;

namespace Modules.Auth.Application.Users.Queries.Handlers;

internal sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginatedList<UserDto>>
{
    private readonly IIdentityService _identityService;

    public GetAllUsersQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<PaginatedList<UserDto>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var (pageNumber, pageSize) = request;
        
        var page = await _identityService.GetAllUsers(pageNumber, pageSize);
        var userDtos = page.Items.Select(UserMapper.UserToUserDto);

        return new PaginatedList<UserDto>(userDtos.ToList(), page.TotalCount, page.PageNumber, page.TotalPages);
    }
}