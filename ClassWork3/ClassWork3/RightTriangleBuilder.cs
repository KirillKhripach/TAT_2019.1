using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for right triangles builders
    /// </summary>
    class RightTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public RightTriangleBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor)
        {

        }

        /// <summary>
        /// Takes three points and builds triangle according to them
        /// Сhecks whether this is a right triangle
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New right triangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            Point vectorFromFirstToSecond = new Point(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point vectorFromFirstToThird = new Point(thirdPoint.X - firstPoint.X, thirdPoint.Y - firstPoint.Y);
            Point vectorFromSecondToThird = new Point(thirdPoint.X - secondPoint.X, thirdPoint.Y - secondPoint.Y);

            if (Math.Abs(vectorFromFirstToSecond.X * vectorFromFirstToThird.X + vectorFromFirstToSecond.Y * vectorFromFirstToThird.Y) < epsilon
                || Math.Abs(vectorFromFirstToSecond.X * vectorFromSecondToThird.X + vectorFromFirstToSecond.Y * vectorFromSecondToThird.Y) < epsilon
                || Math.Abs(vectorFromFirstToThird.X * vectorFromSecondToThird.X + vectorFromFirstToThird.Y * vectorFromSecondToThird.Y) < epsilon)
            {
                return new RightTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build right triangle");
        }
    }
}
