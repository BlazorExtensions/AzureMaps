using System;
using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Models;
using Blazor.Extensions.AzureMaps.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Blazor.Extensions.AzureMaps.Component
{
    public class MapComponent : ComponentBase, IAsyncDisposable
    {
        [Inject] private ILogger<MapComponent> Logger { get; set; } = default!;
        [Inject] public IMapService MapService { get; set; } = default!;
        [Parameter] public MapOptions? Options { get; set; } = default!;
        [Parameter] public DrawingManagerOptions? DrawingManagerOptions { get; set; } = default!;

        protected readonly Guid _mapId;
        private IMapReference _map = default!;
        private IMapDrawingManager _drawingManager = default!;

        public MapComponent()
        {
            this._mapId = Guid.NewGuid();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this._map = await this.MapService
                    .CreateMap(this._mapId, this.Options);
                this._drawingManager = await this.MapService
                    .AddDrawingTool(this._map, this.DrawingManagerOptions);
            }
        }

        public ValueTask DisposeAsync()
        {
            if (this._map != null)
            {
                if (this._drawingManager != null)
                {
                    this._drawingManager.DisposeAsync();
                }
                return this._map.DisposeAsync();
            }

            return ValueTask.CompletedTask;
        }
    }
}
