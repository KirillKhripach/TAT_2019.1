using System;

namespace DevTask6
{
    /// <summary>
    /// Class contains entry point to the program
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// Creates car getter that takes file name from command line
        /// And creates menu
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                // Checks for 1 file name
                if (args.Length != 1)
                {
                    throw new Exception("File name not specified");
                }
                
                CarGetter carGetter = new CarGetter(args[0]);
                Menu menu = new Menu(new CarCatalog(carGetter.GetCars()));
                menu.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
