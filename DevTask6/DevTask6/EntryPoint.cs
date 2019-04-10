using System;
using System.Collections.Generic;

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
                if (args.Length < 2)
                {
                    throw new Exception("File names are not specified");
                }

                CarGetter carGetter = new CarGetter();

                List<CarCatalog> catalogs = new List<CarCatalog>()
                {
                    new CarCatalog(carGetter.GetCars(args[(int)CarTypes.Passenger])),
                    new CarCatalog(carGetter.GetCars(args[(int)CarTypes.Truck]))
                };
                
                Menu menu = new Menu(catalogs);
                menu.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
