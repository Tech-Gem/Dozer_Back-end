using Dozer.Shared.Controllers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modules.Auth.Application.Users.Commands;
using Modules.Auth.Application.Users.Queries;
using Modules.Auth.Shared.DTOs;

namespace Modules.Auth.Api.Controllers;

[Route("/api/v{v:apiVersion}/users")]
public class UserController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(ISender mediator)
    {
        _mediator = mediator;
        
    }

    [HttpPost("create")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUserProfile(CancellationToken cancellationToken, [FromBody] CreateUserProfileDto createUserProfileDto)
    {
        var command = _mapper.Map<CreateUserProfileCommand>(createUserProfileDto);
        var result = await _mediator.Send(command);
            
        return result.Match(Ok, Problem);
        
    }

    // [HttpPut("update/{userId}")]
    // public async Task<IActionResult> UpdateUserProfile(CancellationToken cancellationToken, [FromRoute] string userId, [FromBody] UpdateUserProfileDto updateUserProfileDto)
    // {
    //     var command = _mapper.Map<UpdateUserCommand>(updateUserProfileDto);
    //     command.UserId = userId;
    //     var result = await _mediator.Send(command);
    //         
    //     return result.Match(
    //         Ok,
    //         Problem
    //     );
    // }

    [HttpGet("{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById(CancellationToken cancellationToken, [FromRoute] string userId)
    {
        
        var result = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
            
        return result.Match(
            Ok,
            Problem
        );
    }

    [HttpGet("all")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken, [FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var result = await _mediator.Send(new GetAllUsersQuery(pageNumber, pageSize));
            
        return Ok(result);
    }
}




