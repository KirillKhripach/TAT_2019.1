using System;

namespace DevTask6
{
    /// <summary>
    /// Class for counting brands of cars method
    /// </summary>
    class CountTypesCommand : ICommand
    {
        private CarCatalog Catalog { get; set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        public CountTypesCommand(CarCatalog carCatalog)
        {
            this.Catalog = carCatalog;
        }

        /// <summary>
        /// Calls method for catalog of cars and display count of brands
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(this.Catalog?.GetCarBrandesCount());
        }
    }
}
