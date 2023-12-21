using Dozer.Shared.Models;
using Modules.Auth.Domain.Entities;
using ErrorOr;

namespace Modules.Auth.Application.Service;

public interface IIdentityService
{
    Task<PaginatedList<User>> GetAllUsers(int pageNumber, int pageSize);
    Task<ErrorOr<User>> GetUserById(string userId);
}


