using deploy.core.Providers;
using deploy.core.Providers.Interfaces;
using deploy.core.Services;
using deploy.core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace deploy.core.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors (this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }
        public static void ConfigureServices (this IServiceCollection services)
        {
            services.AddScoped<IDeployService, DeployService>();
        }

        public static void ConfigureProviders (this IServiceCollection services)
        {
            services.AddScoped<IPathProvider, PathProvider>();
        }
    }
}