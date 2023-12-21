using ErrorOr;
using Modules.Auth.Shared.DTOs;

namespace Modules.Auth.Shared;

public interface IIdentityApi
{
    Task<ErrorOr<UserDto>> GetUserById(string userId);
}