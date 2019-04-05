using System;

namespace ClassWork3
{
    /// <summary>
    /// Struct for 2D point
    /// </summary>
    struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        /// <summary>
        /// Constructor initializes coordinates of the point
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculates length of the side between this point and another
        /// </summary>
        /// <param name="point">Another point</param>
        /// <returns>Length of the side</returns>
        public double GetSide(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }
    }
}
