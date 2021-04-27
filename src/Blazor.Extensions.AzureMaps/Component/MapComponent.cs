using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Blazor.Extensions.AzureMaps
{
    public class MapComponent : ComponentBase, IAsyncDisposable
    {
        [Inject] private ILogger<MapComponent> Logger { get; set; } = default!;
        [Inject] public IMapService MapService { get; set; } = default!;
        [Parameter] public MapOptions? Options { get; set; } = default!;

        protected readonly Guid _mapId;
        private IMapReference _map = default!;

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
            }
        }

        public ValueTask DisposeAsync()
        {
            if (this._map != null)
            {
                return this._map.DisposeAsync();
            }

            return ValueTask.CompletedTask;
        }
    }
}
