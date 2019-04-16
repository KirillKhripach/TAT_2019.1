using System;

namespace DevTask6
{
    /// <summary>
    /// Class for executing commands with car catalog
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
            this.Catalog = carCatalog;
        }

        /// <summary>
        /// Executes command according to input data
        /// </summary>
        public void Display()
        {
            bool entry = true;
            Inputer inputer = new Inputer();

            while (entry)
            {     
                switch (inputer.GetCommand())
                {
                    case CatalogCommands.CountTypes:
                        this.Command = new CountTypesCommand(this.Catalog);
                        break;
                    case CatalogCommands.CountAll:
                        this.Command = new CountAllCommand(this.Catalog);
                        break;
                    case CatalogCommands.AveragePrice:
                        this.Command = new AveragePriceCommand(this.Catalog);
                        break;
                    case CatalogCommands.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        this.Command = new AveragePriceTypeCommand(this.Catalog, Console.ReadLine());
                        break;
                    case CatalogCommands.Exit:
                        entry = false;
                        this.Command = null;
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }

                this.Command?.Execute();
            }
        }
    }
}
