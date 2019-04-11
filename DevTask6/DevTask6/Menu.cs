using System;
using System.Collections.Generic;

namespace DevTask6
{
    /// <summary>
    /// Class for user and program interaction
    /// </summary>
    class Menu
    {
        public List<CarCatalog> Catalogs { get; private set; }
        private ICommand Command { get; set; }
        private Action ExecuteCommands { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">List of catalogs</param>
        public Menu(List<CarCatalog> catalogs)
        {
            this.Catalogs = catalogs;
        }

        /// <summary>
        /// Displays information according to chosen command
        /// </summary>
        public void Display()
        {
            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter command(1-6):\n" + "1. Count types\n" + "2. Count all\n"
                    + "3. Average price\n" + "4. Average price type\n" + "5. Execute\n" + "6. Exit");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Incorrect input data");
                    continue;
                }

                switch ((CatalogCommands)input)
                {
                    case CatalogCommands.CountTypes:
                        Command = new CountTypesCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.CountAll:
                        Command = new CountAllCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.AveragePrice:
                        Command = new AveragePriceCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        Command = new AveragePriceTypeCommand(Catalogs[ChooseCarType()], Console.ReadLine());
                        break;

                    case CatalogCommands.Execute:
                        entry = false;
                        Command = null;
                        continue;

                    case CatalogCommands.Exit:
                        entry = false;
                        Command = null;
                        ExecuteCommands = null;
                        continue;

                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }

                ExecuteCommands += Command.Execute;
            }

            ExecuteCommands?.Invoke();
        }

        /// <summary>
        /// Returns int type of car according to chosen type
        /// </summary>
        /// <returns>Int type of car</returns>
        private int ChooseCarType()
        {
            int carType = 0;

            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter type of car(1-2):\n" + $"1. {CarTypes.Passenger}\n" + $"2. {CarTypes.Truck}");

                if (!int.TryParse(Console.ReadLine(), out carType) || carType > Catalogs.Count)
                {
                    Console.WriteLine("Incorrect input data");
                    continue;
                }

                entry = false;
            }

            return --carType;
        }
    }
}
