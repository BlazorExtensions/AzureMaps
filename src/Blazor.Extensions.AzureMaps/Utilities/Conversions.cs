using System;

namespace Blazor.Extensions.AzureMaps.Utilities
{
    public static class Conversions
    {
        /// <summary>
        /// Gets the WGS84 longitude of the northwest corner from a tile's X position and zoom level.
        /// See: http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames.
        /// </summary>
        /// <param name="x"> Tile X position. </param>
        /// <param name="zoom"> Zoom level. </param>
        /// <returns> NW Longitude. </returns>
        public static double TileXToNWLongitude(int x, int zoom)
        {
            var n = Math.Pow(2.0, zoom);
            var lon_deg = x / n * 360.0 - 180.0;
            return lon_deg;
        }

        /// <summary>
        /// Gets the WGS84 latitude of the northwest corner from a tile's Y position and zoom level.
        /// See: http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames.
        /// </summary>
        /// <param name="y"> Tile Y position. </param>
        /// <param name="zoom"> Zoom level. </param>
        /// <returns> NW Latitude. </returns>
        public static double TileYToNWLatitude(int y, int zoom)
        {
            var n = Math.Pow(2.0, zoom);
            var lat_rad = Math.Atan(Math.Sinh(Math.PI * (1 - 2 * y / n)));
            var lat_deg = lat_rad * 180.0 / Math.PI;
            return lat_deg;
        }

        /// <summary>
        /// Gets the <see cref="T:Vector2dBounds"/> of a tile.
        /// </summary>
        /// <param name="x"> Tile X position. </param>
        /// <param name="y"> Tile Y position. </param>
        /// <param name="zoom"> Zoom level. </param>
        /// <returns> The <see cref="T:Vector2dBounds"/> of the tile. </returns>
        public static Vector2dBounds TileIdToBounds(int x, int y, int zoom)
        {
            var sw = new Vector2d(TileYToNWLatitude(y, zoom), TileXToNWLongitude(x + 1, zoom));
            var ne = new Vector2d(TileYToNWLatitude(y + 1, zoom), TileXToNWLongitude(x, zoom));
            return new Vector2dBounds(sw, ne);
        }
    }
}
