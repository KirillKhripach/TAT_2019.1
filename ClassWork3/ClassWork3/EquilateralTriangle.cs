using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for equilateral triangles
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public EquilateralTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint)
        {

        }

        /// <summary>
        /// Calculates square of the equilateral triangle
        /// </summary>
        /// <returns>Value of the square</returns>
        public override double GetSquare()
        {
            double firstSide = FirstPoint.GetSide(SecondPoint);

            return firstSide * firstSide * Math.Sqrt(3) / 4;
        }
    }
}
