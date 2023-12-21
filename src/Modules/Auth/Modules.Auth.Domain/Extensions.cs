using Microsoft.Extensions.DependencyInjection;

namespace Modules.Auth.Domain;

public static class Extensions
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        return services;
    }
}