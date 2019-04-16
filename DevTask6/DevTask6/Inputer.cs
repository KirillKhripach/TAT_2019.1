using System;

namespace DevTask6
{
    /// <summary>
    /// Class for inputting data
    /// </summary>
    class Inputer
    {
        /// <summary>
        /// Returns command according to input data
        /// </summary>
        /// <returns>Chosen command</returns>
        public CatalogCommands GetCommand()
        {
            Console.WriteLine("Enter command(1-5):\n" + "1. Count types\n" + "2. Count all\n"
                    + "3. Average price\n" + "4. Average price type\n" + "5. Exit");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Incorrect input data");
            }

            return (CatalogCommands)input;
        }
    }
}
