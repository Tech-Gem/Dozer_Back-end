using Microsoft.Extensions.DependencyInjection;

namespace Modules.Auth.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services;
    }
}