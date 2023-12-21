namespace Modules.Auth.Shared.DTOs;

public sealed record CreateUserProfileDto(
    string Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string Job,
    string? ProfilePicture
    
);