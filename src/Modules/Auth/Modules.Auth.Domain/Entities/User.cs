using Microsoft.AspNetCore.Identity;

namespace Modules.Auth.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {MiddleName} {LastName}";
    // public string? CompanyId { get; set; }
    public string? Job { get; set; }
    public string? ProfilePicture { get; set; }
}

