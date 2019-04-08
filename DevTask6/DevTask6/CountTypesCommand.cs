using System;

namespace DevTask6
{
    /// <summary>
    /// Сlass for counting brands of cars method
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private CarCatalog Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        public CountTypesCommand(CarCatalog carCatalog)
        {
            Catalog = carCatalog;
        }

        /// <summary>
        /// Calls method for catalog of cars and display count of brands
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Catalog.GetCarBrandesCount());
        }
    }
}
