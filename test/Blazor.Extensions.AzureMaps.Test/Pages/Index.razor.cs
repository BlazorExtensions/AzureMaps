using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.AzureMaps.Test.Pages
{
    public partial class Index : IComponent
    {
        private MapComponent azureMaps;

        protected DrawingManagerOptions drawingManagerOptions = new DrawingManagerOptions
            {Toolbar = new DrawingToolbar {Options = new DrawingToolbarOptions {Position = "top-right"}}};
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return Task.CompletedTask;
        }
    }
}
