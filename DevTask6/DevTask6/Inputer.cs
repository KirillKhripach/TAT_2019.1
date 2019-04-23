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
            Console.WriteLine("Enter command(1-6):\n" + "1. Count types\n" + "2. Count all\n"
                    + "3. Average price\n" + "4. Average price type\n" + "5. Execute\n" + "6. Exit");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Incorrect input data");
            }

            return (CatalogCommands)input;
        }

        /// <summary>
        /// Returns int type of cars according to input data
        /// </summary>
        /// <returns>Int type of cars</returns>
        public int ChooseCarType(int catalogsCount)
        {
            Console.WriteLine("Enter type of car(1-2):\n" + $"1. {CarType.Passenger}\n" + $"2. {CarType.Truck}");

            // Checks that number is int and in range of count of catalogs(1 - catalogsCount)
            if (!int.TryParse(Console.ReadLine(), out int carType) || carType < 1 || carType > catalogsCount)
            {
                throw new Exception("Incorrect input data");
            }

            // Decreases by one, because collections start numbering from zero
            return --carType;
        }
    }
}
