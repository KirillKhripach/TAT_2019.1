using System;

namespace DevTask4
{
    /// <summary>
    /// Main class that contains entry point
    /// Creates new discipline, implements deep cloning and indexator
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                Discipline discipline = new Discipline();
                Console.WriteLine(discipline.ToString());
                Discipline disciplineClone = (Discipline)discipline.Clone();

                //Checks for equals an entity and its clone
                Console.WriteLine(discipline.Equals(disciplineClone) ? "Successful cloning" : throw new Exception("Failed cloning"));

                //Compares the links of the first lecture of the entity and its clone
                //[0][0] - indexator, turns to the first lecture
                Console.WriteLine(discipline[0][0] != disciplineClone[0][0] ? "Deep cloning" : "Surface cloning");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
