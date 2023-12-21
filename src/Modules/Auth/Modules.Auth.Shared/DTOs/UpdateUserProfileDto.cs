namespace Modules.Auth.Shared.DTOs;

public sealed record UpdateUserProfileDto(
    string Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string PhoneNumber,
    // string? CompanyId,
    string Job,
    string? ProfilePicture
    
);