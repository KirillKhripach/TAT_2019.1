using System;

namespace DevTask6
{
    /// <summary>
    /// Class for user and program interaction
    /// </summary>
    class Menu
    {
        public CarCatalog Catalog { get; private set; }
        private ICommand Command { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        public Menu(CarCatalog carCatalog)
        {
            Catalog = carCatalog;
        }

        /// <summary>
        /// Displays information according to chosen command
        /// </summary>
        public void Display()
        {
            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter command(1-5):\n" + "1. Count types\n" + "2. Count all\n"
                    + "3. Average price\n" + "4. Average price type\n" + "5. Exit");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Incorrect input data");
                    continue;
                }

                switch ((CatalogCommands)input)
                {
                    case CatalogCommands.CountTypes:
                        Command = new CountTypesCommand(Catalog);
                        break;

                    case CatalogCommands.CountAll:
                        Command = new CountAllCommand(Catalog);
                        break;

                    case CatalogCommands.AveragePrice:
                        Command = new AveragePriceCommand(Catalog);
                        break;

                    case CatalogCommands.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        Command = new AveragePriceTypeCommand(Catalog, Console.ReadLine());
                        break;

                    case CatalogCommands.Exit:
                        entry = false;
                        Command = null;
                        break;

                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }

                Command?.Execute();
            }
        }
    }
}
