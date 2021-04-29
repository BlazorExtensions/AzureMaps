using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Services;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    internal class MapDrawingManager : IMapDrawingManager
    {
        private const string DisposeMethod = "dispose";
        private readonly IJSObjectReference _jsReference;

        public MapDrawingManager(IJSObjectReference jsReference)
        {
            this._jsReference = jsReference;
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await this._jsReference.InvokeVoidAsync(DisposeMethod);
                await this._jsReference.DisposeAsync();
            }
            catch (TaskCanceledException)
            {
                // The browser refresh and SignalR connection was broken.
            }
        }
    }
}