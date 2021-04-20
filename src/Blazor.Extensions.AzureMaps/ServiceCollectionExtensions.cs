using Blazor.Extensions.AzureMaps.Util;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Extensions.AzureMaps
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureMapsCssAndJs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<AzureMapsInterop>();
            serviceCollection.AddTransient<IAzureMapsCssAndJs, AzureMapsCssAndJs>();
            return serviceCollection;
        }
    }
}
