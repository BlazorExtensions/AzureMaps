using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    internal class MapService : IMapService
    {
        private const string AzureMapsScriptName = "./_content/Blazor.Extensions.AzureMaps/BE.AzureMaps.js";
        private const string InitAzureMapsMethod = "init";
        private const string AzureMapsClass = "BEAzureMaps";
        private const string CreateMapMethod = "createMap";
        private const string AddDrawingToolsMethod = "addDrawingTools";
        private const string ImportJSModuleMethod = "import";
        private readonly AzureMapsOptions options;
        private readonly IJSRuntime runtime;
        private IJSObjectReference azureMapsModule = default!;

        public MapService(IOptions<AzureMapsOptions> options, IJSRuntime runtime)
        {
            this.runtime = runtime;
            if (string.IsNullOrWhiteSpace(options.Value.SubscriptionKey)) throw new ArgumentNullException(nameof(options.Value.SubscriptionKey));
            this.options = options.Value;
        }

        public async Task<IMapReference> CreateMap(Guid mapId, MapOptions? mapOptions)
        {
            await this.EnsureModuleLoaded();

            var jsReference = await this.azureMapsModule
                    .InvokeAsync<IJSObjectReference>(
                        $"{AzureMapsClass}.{CreateMapMethod}",
                        mapId,
                        mapOptions
                    );
            return new MapReference(mapId, jsReference);
        }

        public async Task AddDrawingTool(IMapReference mapReference, DrawingManagerOptions? drawingManagerOptions)
        {
            await this.EnsureModuleLoaded();

            await this.azureMapsModule
                .InvokeVoidAsync(
                    $"{AzureMapsClass}.{AddDrawingToolsMethod}",
                    mapReference.Map,
                    drawingManagerOptions
                );
        }

        private async ValueTask EnsureModuleLoaded()
        {
            if (this.azureMapsModule != null) return;

            this.azureMapsModule = await this.runtime.InvokeAsync<IJSObjectReference>(
                ImportJSModuleMethod, AzureMapsScriptName);

            await this.azureMapsModule.InvokeVoidAsync($"{AzureMapsClass}.{InitAzureMapsMethod}", this.options.SubscriptionKey);
        }
    }
}