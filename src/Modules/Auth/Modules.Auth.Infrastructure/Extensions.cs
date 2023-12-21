using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Dozer.Shared.Database;
using Microsoft.AspNetCore.Identity;
using Modules.Auth.Domain.Entities;
using Modules.Auth.Infrastructure.Persistence;

namespace Modules.Auth.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPostgres<AuthDbContext>();
        services.AddAuth(configuration);
        return services;
    }

    private static void AddAuth(this IServiceCollection services,
        IConfiguration configuration)
    {
        int.TryParse(configuration["Lockout:DefaultLockoutTimeInHour"], out var lockoutTimeout);
        int.TryParse(configuration["Lockout:MaxFailedAccessAttempts"], out var maxFailedAccessAttempts);

        services.AddAuthorization();

        services.AddIdentityApiEndpoints<User>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                    options.User.RequireUniqueEmail = true;

                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = maxFailedAccessAttempts;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(lockoutTimeout);
                }
            )
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>();

    }
}

