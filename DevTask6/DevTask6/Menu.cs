using System;
using System.Collections.Generic;

namespace DevTask6
{
    /// <summary>
    /// Class for executing commands with car catalogs
    /// </summary>
    class Menu
    {
        private ICommand Command { get; set; }
        private Action ExecuteCommands { get; set; }
        public List<CarCatalog> Catalogs { get; private set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="carCatalog">List of catalogs</param>
        public Menu(List<CarCatalog> catalogs)
        {
            this.Catalogs = catalogs;
        }

        /// <summary>
        /// Executes commands according to input data
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
                        this.Command = new CountTypesCommand(this.Catalogs[inputer.ChooseCarType(this.Catalogs.Count)]);
                        break;
                    case CatalogCommands.CountAll:
                        this.Command = new CountAllCommand(this.Catalogs[inputer.ChooseCarType(this.Catalogs.Count)]);
                        break;
                    case CatalogCommands.AveragePrice:
                        this.Command = new AveragePriceCommand(this.Catalogs[inputer.ChooseCarType(this.Catalogs.Count)]);
                        break;
                    case CatalogCommands.AveragePriceType:
                        var catalog = this.Catalogs[inputer.ChooseCarType(this.Catalogs.Count)];
                        Console.WriteLine("Enter car brand:");
                        this.Command = new AveragePriceTypeCommand(catalog, Console.ReadLine());
                        break;
                    case CatalogCommands.Execute:
                        entry = false;
                        this.Command = null;
                        continue;
                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }

                this.ExecuteCommands += this.Command.Execute;
            }

            this.ExecuteCommands?.Invoke();
        }
    }
}
