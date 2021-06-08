using System;
using System.Collections.Generic;
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
        [Parameter] public DrawingManagerOptions? DrawingManagerOptions { get; set; } = default!;

        protected readonly Guid MapId;
        private IMapReference map = default!;
        private IMapDrawingManager drawingManager = default!;

        public MapComponent()
        {
            this.MapId = Guid.NewGuid();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.map = await this.MapService
                    .CreateMap(this.MapId, this.Options);
                //if (this.DrawingManagerOptions != null)
                //{
                //    await this.MapService
                //        .AddDrawingTool(this.map, this.DrawingManagerOptions);
                //}
            }
        }

        public async Task SetLocation(MapOptions cameraOptions)
        {
            await this.MapService.SetLocation(cameraOptions);
        }

        public async Task DrawLocation(DrawingManagerOptions opts)
        {
            await this.MapService.DrawLocation(opts);
        }

        public async Task ClearShapes()
        {
            await this.MapService.ClearShapes();
        }

        public async Task<List<List<int>>> GetTiles()
        {
            return await this.MapService.GetTiles();
        }

        public ValueTask DisposeAsync()
        {
            if (this.map != null)
            {
                this.drawingManager?.DisposeAsync();
                return this.map.DisposeAsync();
            }

            return ValueTask.CompletedTask;
        }
    }
}
