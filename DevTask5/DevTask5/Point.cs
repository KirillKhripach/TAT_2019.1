using System;

namespace DevTask5
{
    /// <summary>
    /// Struct for a 3D point
    /// </summary>
    struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Calculates distance between this point and another
        /// </summary>
        /// <param name="newPoint">Another point</param>
        /// <returns>Distance between points</returns>
        public double GetDistance(Point newPoint)
        {
            return Math.Sqrt(Math.Pow(newPoint.X - X, 2) + Math.Pow(newPoint.Y - Y, 2) + Math.Pow(newPoint.Z - Z, 2));
        }
    }
}
