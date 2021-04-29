using System;
using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Models;

namespace Blazor.Extensions.AzureMaps.Services
{
    public interface IMapService
    {
        Task<IMapReference> CreateMap(Guid mapId, MapOptions? options);
        Task<IMapDrawingManager> AddDrawingTool(IMapReference map, DrawingManagerOptions? drawingManagerOptions);
    }
}