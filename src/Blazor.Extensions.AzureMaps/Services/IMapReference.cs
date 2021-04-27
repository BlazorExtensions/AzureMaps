using System;

namespace Blazor.Extensions.AzureMaps
{
    public interface IMapReference : IAsyncDisposable
    {
        Guid MapId { get; }
    }
}