using System;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Extensions.AzureMaps
{
    public static class HostingExtensions
    {
        public static IServiceCollection AddAzureMaps(this IServiceCollection services, Action<AzureMapsOptions> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            return services
                .Configure<AzureMapsOptions>(configure)
                .AddAzureMaps();
        }

        public static IServiceCollection AddAzureMaps(this IServiceCollection services)
        {
            return services
                .AddScoped<IMapService, MapService>();
        }
    }
}