using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    internal class MapReference : IMapReference
    {
        private const string DisposeMethod = "dispose";
        private readonly IJSObjectReference _jsReference;

        public Guid MapId { get; private set; }

        public MapReference(Guid id, IJSObjectReference jsReference)
        {
            this.MapId = id;
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