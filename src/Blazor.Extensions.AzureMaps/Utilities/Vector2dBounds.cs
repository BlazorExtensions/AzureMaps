using System.Collections.Generic;

namespace Blazor.Extensions.AzureMaps.Utilities
{
    public class Vector2dBounds
    {
        /// <summary> Southwest corner of bounding box. </summary>
        public Vector2d SouthWest;

        /// <summary> Northeast corner of bounding box. </summary>
        public Vector2d NorthEast;

        /// <summary> Initializes a new instance of the <see cref="Vector2dBounds" /> class. </summary>
        /// <param name="sw"> Geographic coordinate representing southwest corner of bounding box. </param>
        /// <param name="ne"> Geographic coordinate representing northeast corner of bounding box. </param>
        public Vector2dBounds(Vector2d sw, Vector2d ne)
        {
            this.SouthWest = sw;
            this.NorthEast = ne;
        }

        /// <summary> Gets the south latitude. </summary>
        /// <value> The south latitude. </value>
        public double South => this.SouthWest.X;

        /// <summary> Gets the west longitude. </summary>
        /// <value> The west longitude. </value>
        public double West => this.SouthWest.Y;

        /// <summary> Gets the north latitude. </summary>
        /// <value> The north latitude. </value>
        public double North => this.NorthEast.X;

        /// <summary> Gets the east longitude. </summary>
        /// <value> The east longitude. </value>
        public double East => this.NorthEast.Y;

        /// <summary>
        ///     Gets or sets the central coordinate of the bounding box. When
        ///     setting a new center, the bounding box will retain its original size.
        /// </summary>
        /// <value> The central coordinate. </value>
        public Vector2d Center
        {
            get
            {
                var lat = (this.SouthWest.X + this.NorthEast.X) / 2;
                var lng = (this.SouthWest.Y + this.NorthEast.Y) / 2;

                return new Vector2d(lat, lng);
            }

            set
            {
                var lat = (this.NorthEast.X - this.SouthWest.X) / 2;
                this.SouthWest.X = value.X - lat;
                this.NorthEast.X = value.X + lat;

                var lng = (this.NorthEast.Y - this.SouthWest.Y) / 2;
                this.SouthWest.Y = value.Y - lng;
                this.NorthEast.Y = value.Y + lng;
            }
        }

        /// <summary>
        ///     Creates a bound from two arbitrary points. Contrary to the constructor,
        ///     this method always creates a non-empty box.
        /// </summary>
        /// <param name="a"> The first point. </param>
        /// <param name="b"> The second point. </param>
        /// <returns> The convex hull. </returns>
        public static Vector2dBounds FromCoordinates(Vector2d a, Vector2d b)
        {
            var bounds = new Vector2dBounds(a, a);
            bounds.Extend(b);

            return bounds;
        }

        /// <summary> A bounding box containing the world. </summary>
        /// <returns> The world bounding box. </returns>
        public static Vector2dBounds World()
        {
            var sw = new Vector2d(-90, -180);
            var ne = new Vector2d(90, 180);

            return new Vector2dBounds(sw, ne);
        }

        /// <summary> Extend the bounding box to contain the point. </summary>
        /// <param name="point"> A geographic coordinate. </param>
        public void Extend(Vector2d point)
        {
            if (point.X < this.SouthWest.X)
            {
                this.SouthWest.X = point.X;
            }

            if (point.X > this.NorthEast.X)
            {
                this.NorthEast.X = point.X;
            }

            if (point.Y < this.SouthWest.Y)
            {
                this.SouthWest.Y = point.Y;
            }

            if (point.Y > this.NorthEast.Y)
            {
                this.NorthEast.Y = point.Y;
            }
        }

        /// <summary> Extend the bounding box to contain the bounding box. </summary>
        /// <param name="bounds"> A bounding box. </param>
        public void Extend(Vector2dBounds bounds)
        {
            this.Extend(bounds.SouthWest);
            this.Extend(bounds.NorthEast);
        }

        /// <summary> Whenever the geographic bounding box is empty. </summary>
        /// <returns> <c>true</c>, if empty, <c>false</c> otherwise. </returns>
        public bool IsEmpty()
        {
            return this.SouthWest.X > this.NorthEast.X ||
                       this.SouthWest.Y > this.NorthEast.Y;
        }

        /// <summary>
        /// Converts to an array of doubles.
        /// </summary>
        /// <returns>An array of coordinates.</returns>
        public double[] ToArray()
        {
            double[] array =
            {
                this.SouthWest.X,
                this.SouthWest.Y,
                this.NorthEast.X,
                this.NorthEast.Y
            };

            return array;
        }

        public List<List<double>> ToPolygonList()
        {
            var list = new List<List<double>>
            {
                new List<double> {this.SouthWest.Y,this.SouthWest.X },
                new List<double> {this.SouthWest.Y,this.NorthEast.X },
                new List<double> {this.NorthEast.Y,this.NorthEast.X },
                new List<double> {this.NorthEast.Y,this.SouthWest.X },
                new List<double> {this.SouthWest.Y,this.SouthWest.X }
            };

            return list;
        }

        /// <summary> Converts the Bbox to a URL snippet. </summary>
        /// <returns> Returns a string for use in a Mapbox query URL. </returns>
        public override string ToString()
        {
            return $"{this.SouthWest},{this.NorthEast}";
        }
    }
}
