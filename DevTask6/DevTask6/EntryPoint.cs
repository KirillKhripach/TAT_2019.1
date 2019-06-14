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
        /// Creates car getter that takes file names from command line
        /// Creates menu with list of car catalogs
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                // Checks for 2 file names
                if (args.Length != 2)
                {
                    throw new Exception("File names are not specified");
                }

                CarGetter carGetter = CarGetter.GetInstance();

                List<CarCatalog> catalogs = new List<CarCatalog>()
                {
                    new CarCatalog(carGetter.GetCars(args[(int)CarType.Passenger])),
                    new CarCatalog(carGetter.GetCars(args[(int)CarType.Truck]))
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
