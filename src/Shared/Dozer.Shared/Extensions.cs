using System.Text.Json.Serialization;
using Dozer.Shared.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Dozer.Shared;

public static class Extensions
{
    
    private const string ApiTitle = "Dozer API";
    private const string ApiVersion = "v1";

    private const string SecurityScheme = "Bearer";
    private const string SecuritySchemeDesc = "Please enter a valid token";
    private const string SecuritySchemeName = "Authorization";
    private const string BearerFormat = "JWT";

    private const int MajorVersion = 1;
    private const int MinorVersion = 0;
    
    public static IServiceCollection AddSharedFramework(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddPostgres(configuration);

        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = ApiTitle, Version = ApiVersion });
            option.AddSecurityDefinition(
                SecurityScheme,
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = SecuritySchemeDesc,
                    Name = SecuritySchemeName,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = BearerFormat,
                    Scheme = SecurityScheme
                }
            );
            option.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                }
            );
        });

        services.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(MajorVersion, MinorVersion);
        });
        return services;
    }

    public static IApplicationBuilder UseSharedFramework(
        this IApplicationBuilder app
    )
    {
        app.UseRouting();
        return app;
    }
}