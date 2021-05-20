using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.AzureMaps.Test.Pages
{
    public partial class Index : IComponent
    {
        private MapComponent azureMaps;
        private double Latitude { get; set; }
        private double Longitude { get; set; }
        private int Radius { get; set; }
        
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return Task.CompletedTask;
        }

        protected async Task SetLocation()
        {
            await this.azureMaps.ClearShapes();

            var opts = new MapOptions
            {
                Center = new []{ this.Longitude, this.Latitude },
                Zoom = 22
            };

            var drawingManagerOptions = new DrawingManagerOptions
            {
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Radius = this.Radius
            };

            await this.azureMaps.SetLocation(opts);
            await this.azureMaps.DrawLocation(drawingManagerOptions);
        }
    }
}
