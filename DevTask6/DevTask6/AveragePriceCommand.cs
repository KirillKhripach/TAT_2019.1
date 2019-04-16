using System;

namespace DevTask6
{
    /// <summary>
    /// Сlass for counting average price method
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private CarCatalog Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        public AveragePriceCommand(CarCatalog carCatalog)
        {
            this.Catalog = carCatalog;
        }

        /// <summary>
        /// Calls method for catalog of cars and display average price of cars
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(this.Catalog?.GetAveragePrice());
        }
    }
}
