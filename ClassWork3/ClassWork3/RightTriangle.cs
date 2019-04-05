namespace ClassWork3
{
    /// <summary>
    /// Class for right triangles
    /// </summary>
    class RightTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public RightTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint)
        {

        }

        /// <summary>
        /// Calculates square of the equilateral triangle
        /// </summary>
        /// <returns>Value of the square</returns>
        public override double GetSquare()
        {
            double firstSide = FirstPoint.GetSide(SecondPoint);
            double secondSide = FirstPoint.GetSide(ThirdPoint);
            double thirdSide = SecondPoint.GetSide(ThirdPoint);

            if (firstSide < thirdSide && secondSide < thirdSide)
            {
                return firstSide * secondSide / 2;
            }

            if (firstSide < secondSide && thirdSide < secondSide)
            {
                return firstSide * thirdSide / 2;
            }

            return secondSide * thirdSide / 2;
        }
    }
}
