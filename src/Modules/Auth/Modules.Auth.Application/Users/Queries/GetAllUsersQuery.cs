using Dozer.Shared.Models;
using MediatR;
using ErrorOr;
using Modules.Auth.Shared.DTOs;

namespace Modules.Auth.Application.Users.Queries;

public record GetAllUsersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedList<UserDto>>;