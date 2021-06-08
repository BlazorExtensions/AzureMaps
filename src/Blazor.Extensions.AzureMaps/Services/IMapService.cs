using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Extensions.AzureMaps
{
    public interface IMapService
    {
        Task<IMapReference> CreateMap(Guid mapId, MapOptions? options);
        Task AddDrawingTool(IMapReference mapReference, DrawingManagerOptions? drawingManagerOptions);
        Task SetLocation(MapOptions cameraOptions);
        Task DrawLocation(DrawingManagerOptions opts);
        Task ClearShapes();
        Task<List<List<int>>> GetTiles();
    }
}