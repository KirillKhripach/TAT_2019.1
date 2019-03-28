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
                Discipline discipline = new Discipline();
                Console.WriteLine(discipline.ToString());
                Discipline disciplineClone = (Discipline)discipline.Clone();
                Console.WriteLine(discipline.Equals(disciplineClone) ? "Successful cloning" : "Something wrong");
                Console.WriteLine(discipline[0][0] != disciplineClone[0][0] ? "Deep cloning" : "Surface cloning");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
