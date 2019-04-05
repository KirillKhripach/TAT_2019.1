namespace ClassWork3
{
    /// <summary>
    /// Abstract class for triangles
    /// </summary>
    abstract class Triangle
    {
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public Point ThirdPoint { get; private set; }

        /// <summary>
        /// Constructor initializes points of the triangle
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        /// <summary>
        /// Abstract method calculates square of the triangle
        /// </summary>
        /// <returns>Value of the square</returns>
        public abstract double GetSquare();
    }
}
