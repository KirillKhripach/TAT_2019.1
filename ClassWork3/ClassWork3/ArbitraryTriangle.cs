using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for arbitrary triangles
    /// </summary>
    class ArbitraryTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public ArbitraryTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint)
        {

        }

        /// <summary>
        /// Calculates square of the arbitrary triangle
        /// </summary>
        /// <returns>Value of the square</returns>
        public override double GetSquare()
        {
            double firstSide = FirstPoint.GetSide(SecondPoint);
            double secondSide = FirstPoint.GetSide(ThirdPoint);
            double thirdSide = SecondPoint.GetSide(ThirdPoint);
            double poluPim = (firstSide + secondSide + thirdSide) / 2;
            
            return Math.Sqrt(poluPim * (poluPim  - firstSide) * (poluPim - secondSide) * (poluPim - thirdSide));
        }
    }
}
