using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for equilateral triangles builders
    /// </summary>
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public EquilateralTriangleBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor)
        {

        }

        /// <summary>
        /// Takes three points and builds triangle according to them
        /// Сhecks whether this is a equilateral triangle
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New equilateral triangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            double firstSide = firstPoint.GetSide(secondPoint);
            double secondSide = firstPoint.GetSide(thirdPoint);
            double thirdSide = secondPoint.GetSide(thirdPoint);

            Console.WriteLine(Math.Abs(firstSide - secondSide));
            Console.WriteLine(Math.Abs(firstSide - thirdSide));
            Console.WriteLine(Math.Abs(secondSide - thirdSide));

            if (Math.Abs(firstSide - secondSide) < epsilon
                && Math.Abs(firstSide - thirdSide) < epsilon
                && Math.Abs(secondSide - thirdSide) < epsilon)
            {
                return new EquilateralTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build equilateral triangle");
        }
    }
}
