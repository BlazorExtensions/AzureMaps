using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Extensions.AzureMaps
{
    public interface IMapService
    {
        Task<IMapReference> CreateMap(Guid mapId, MapOptions? options);
        Task AddDrawingTool(IMapReference mapReference, DrawingManagerOptions? drawingManagerOptions);
        Task SetCamera(MapOptions options);
        Task AddShape(DrawingManagerOptions opts, string id, ShapeProperties? properties);
        Task ClearShapes();
        Task ClearTiles();
        Task<List<List<int>>> GetTiles();
        Task AddPolygonByTiles(List<List<int>> tiles, int zoom, string datasourceId, string id, PolygonOptions properties);
    }
}