namespace Modules.Auth.Shared.DTOs;

public sealed record UserDto(
    string Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string FullName,
    string Email,
    string? PhoneNumber,
    // string? CompanyId,
    string Job,
    string? ProfilePicture
);


