using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Contas;

public class Startup
{
    public IConfiguration _configuration { get; }

    public Startup(IWebHostEnvironment environment)
    {

        var builder = new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsStaging())
        {
            app.SwaggerApplicationConfig();
        }
        app.UseMetrics();
        app.UseAuthentication();
        app.UseAuthorization();
        app.ApiApplicationConfig(env);
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDependencies(_configuration);
        services.ApiServiceConfig();
        services.AutoMapperServiceConfig();
        services.SwaggerServiceConfig();

    }
}
