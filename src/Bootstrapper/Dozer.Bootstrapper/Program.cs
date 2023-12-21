using System.Text.Json.Serialization;
using Dozer.Shared;
using Modules.Auth.Api;
using Modules.Auth.Domain.Entities;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.Console()
    .CreateBootstrapLogger();

// try
// {
    Log.Information("Starting web host");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(
        (context, service, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(service)
            .Enrich.FromLogContext());

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
    
    builder.Services.AddAuthModule(builder.Configuration);
    builder.Services.AddSharedFramework(builder.Configuration);
    

    var app = builder.Build();
    
    app.UseSerilogRequestLogging(configure =>
        configure.MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} Responded {StatusCode} in {Elapsed:0.0000}ms");
    
    app.UseAuthModule();
    app.UseSharedFramework();
    

    // if (app.Environment.IsDevelopment())
    // {
        app.UseSwagger();
        app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    app.UseForwardedHeaders();
    app.UseCors();
    app.MapIdentityApi<User>();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MapGet("/", ctx => ctx.Response.WriteAsync("Dozer API has started"));

    app.Run();
// }
// catch (Exception ex)
// {
//     Log.Fatal(ex, "Host terminated unexpectedly");
// }
// finally
// {
//     Log.CloseAndFlush();
// }