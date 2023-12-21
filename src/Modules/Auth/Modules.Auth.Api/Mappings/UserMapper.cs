using Modules.Auth.Application.Users.Commands;
using Modules.Auth.Shared.DTOs;
using Riok.Mapperly.Abstractions;

namespace Modules.Auth.Api.Mappings;


[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class UserMapper
{
    public static partial CreateUserProfileCommand CreateUserDtoToCreateUserCommand(CreateUserProfileDto createUserProfileDto);
}