using System;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps
{
    public interface IMapReference : IAsyncDisposable
    {
        Guid MapId { get; }
        IJSObjectReference Map { get; }
    }
}