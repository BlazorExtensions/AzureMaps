using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.AzureMaps
{
    public interface IMapService
    {
        Task<IMapReference> CreateMap(Guid mapId, MapOptions? options);
    }
}