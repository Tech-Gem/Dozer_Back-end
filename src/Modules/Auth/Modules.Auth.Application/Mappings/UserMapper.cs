using Modules.Auth.Domain.Entities;
using Modules.Auth.Shared.DTOs;
using Riok.Mapperly.Abstractions;

namespace Modules.Auth.Application.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class UserMapper
{
    public static partial UserDto UserToUserDto(User user);
    
}
