using System;

namespace DevTask6
{
    /// <summary>
    /// Сlass for counting average price method for a specific brand
    /// </summary>
    class AveragePriceTypeCommand : ICommand
    {
        private CarCatalog Catalog { get; set; }
        private string Brand { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        /// <param name="brand">Brand for counting</param>
        public AveragePriceTypeCommand(CarCatalog carCatalog, string brand)
        {
            this.Catalog = carCatalog;
            this.Brand = brand;
        }

        /// <summary>
        /// Calls method for catalog of cars and display average price of a specific brand cars
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(this.Catalog?.GetAveragePriceBrand(this.Brand));
        }
    }
}
