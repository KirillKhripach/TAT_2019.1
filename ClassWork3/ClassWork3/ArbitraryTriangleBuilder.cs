using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for arbitrary triangles builders
    /// </summary>
    class ArbitraryTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public ArbitraryTriangleBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor)
        {

        }

        /// <summary>
        /// Takes three points and builds triangle according to them
        /// Сhecks whether this is a arbitrary triangle
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New arbitrary triangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            if (!(Math.Abs(firstPoint.X - secondPoint.X) < epsilon && Math.Abs(firstPoint.X - thirdPoint.X) < epsilon)
                && !(Math.Abs(firstPoint.Y - secondPoint.Y) < epsilon && Math.Abs(firstPoint.Y - thirdPoint.Y) < epsilon))
            {
                return new ArbitraryTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build arbitrary triangle");

        }
    }
}
