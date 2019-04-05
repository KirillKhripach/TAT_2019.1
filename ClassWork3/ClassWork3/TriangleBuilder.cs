namespace ClassWork3
{
    /// <summary>
    /// Abstract class for triangle builders
    /// </summary>
    abstract class TriangleBuilder
    {
        public TriangleBuilder Successor { get; private set; }

        //calculation error 1E-10
        protected const double epsilon = 1E-10;

        /// <summary>
        /// Contructor initializes successor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public TriangleBuilder(TriangleBuilder triangleBuilderSuccessor)
        {
            Successor = triangleBuilderSuccessor;
        }

        /// <summary>
        /// Abstract method takes three points
        /// And builds triangle according to them
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New triangle</returns>
        public abstract Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint);
    }
}
