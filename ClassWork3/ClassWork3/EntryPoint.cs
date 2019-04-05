using System;

namespace ClassWork3
{
    /// <summary>
    /// Class contains entry point to the program
    /// For calculating square of the triangle
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point creates triangle builder and it builds triangle with three points
        /// If successfully then gets square of the triangle
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                TriangleBuilder triangleBuilder = new RightTriangleBuilder(
                    new EquilateralTriangleBuilder(
                        new ArbitraryTriangleBuilder(null)));

                //Three points define a equilateral triangle
                Triangle triangle = triangleBuilder.Build(new Point(0, 0), new Point(0.5, Math.Sqrt(3.0 / 4.0)), new Point(1, 0));
                Console.WriteLine($"Square of triangle is {triangle?.GetSquare().ToString() ?? "undefined"}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
