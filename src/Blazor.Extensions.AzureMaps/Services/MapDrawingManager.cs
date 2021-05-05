using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    internal class MapDrawingManager : IMapDrawingManager
    {
        private const string DisposeMethod = "dispose";
        private readonly IJSObjectReference jsReference;

        public MapDrawingManager(IJSObjectReference jsReference)
        {
            this.jsReference = jsReference;
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await this.jsReference.InvokeVoidAsync(DisposeMethod);
                await this.jsReference.DisposeAsync();
            }
            catch (TaskCanceledException)
            {
                // The browser refresh and SignalR connection was broken.
            }
        }
    }
}