using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    internal class MapReference : IMapReference
    {
        private const string DisposeMethod = "dispose";
        public IJSObjectReference Map { get; }

        public Guid MapId { get; private set; }

        public MapReference(Guid id, IJSObjectReference jsReference)
        {
            this.MapId = id;
            this.Map = jsReference;
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await this.Map.InvokeVoidAsync(DisposeMethod);
                await this.Map.DisposeAsync();
            }
            catch (TaskCanceledException)
            {
                // The browser refresh and SignalR connection was broken.
            }
        }
    }
}