using System;

namespace DevTask4
{
    /// <summary>
    /// Main class that contains entry point
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                Lecture lecture = new Lecture();
                Console.WriteLine(lecture.LecturePresentation.URI);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
