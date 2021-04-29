using System;
using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Models;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps.Services
{
    internal class MapService : IMapService
    {
        private const string AzureMapsScriptName = "./_content/Blazor.Extensions.AzureMaps/BE.AzureMaps.js";
        private const string InitAzureMapsMethod = "init";
        private const string CreateMapMethod = "createMap";
        private const string AddDrawingToolsMethod = "addDrawingTools";
        private const string ImportJSModuleMethod = "import";
        private readonly AzureMapsOptions _options;
        private readonly IJSRuntime _runtime;
        private IJSObjectReference _azureMapsModule = default!;

        public MapService(IOptions<AzureMapsOptions> options, IJSRuntime runtime)
        {
            this._runtime = runtime;
            if (string.IsNullOrWhiteSpace(options.Value.SubscriptionKey)) throw new ArgumentNullException(nameof(options.Value.SubscriptionKey));
            this._options = options.Value;
        }

        public async Task<IMapReference> CreateMap(Guid mapId, MapOptions? mapOptions)
        {
            await this.EnsureModuleLoaded();

            var jsReference = await this._azureMapsModule
                    .InvokeAsync<IJSObjectReference>(
                        CreateMapMethod,
                        mapId,
                        mapOptions
                    );
            return new MapReference(mapId, jsReference);
        }

        public async Task<IMapDrawingManager> AddDrawingTool(IMapReference map, DrawingManagerOptions? drawingManagerOptions)
        {
            await this.EnsureModuleLoaded();

            var jsReference = await this._azureMapsModule
                .InvokeAsync<IJSObjectReference>(
                    AddDrawingToolsMethod,
                    map,
                    drawingManagerOptions
                );
            return new MapDrawingManager(jsReference);
        }

        private async ValueTask EnsureModuleLoaded()
        {
            if (this._azureMapsModule != null) return;

            this._azureMapsModule = await this._runtime.InvokeAsync<IJSObjectReference>(
                ImportJSModuleMethod, AzureMapsScriptName);

            await this._azureMapsModule.InvokeVoidAsync(InitAzureMapsMethod, this._options.SubscriptionKey);
        }
    }
}