using System;
using System.Collections.Generic;
using System.Linq;

namespace DevTask6
{
    /// <summary>
    /// Class for collection of cars and methods that give information about it
    /// </summary>
    class CarCatalog
    {
        public IEnumerable<Car> Cars { get; private set; }

        /// <summary>
        /// Constructor initializes properties
        /// </summary>
        /// <param name="cars">List of cars</param>
        public CarCatalog(IEnumerable<Car> cars)
        {
            this.Cars = cars;
        }

        /// <summary>
        /// Calculates count of brands
        /// </summary>
        /// <returns>Count of brands</returns>
        public int GetCarBrandesCount()
        {
            return this.Cars.GroupBy(car => car.Brand).Count();
        }

        /// <summary>
        /// Calculates count of cars
        /// </summary>
        /// <returns>Count of cars</returns>
        public int GetCarsCount()
        {
            return this.Cars.Select(car => car.Count).Sum();
        }

        /// <summary>
        /// Calculates average price
        /// </summary>
        /// <returns>Average price</returns>
        public double GetAveragePrice()
        {
            return this.Cars.Select(car => car.Price).Average();
        }

        /// <summary>
        /// Calculates average price of brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Average price</returns>
        public double GetAveragePriceBrand(string brand)
        {
            if (this.Cars.Select(car => car.Brand).Contains(brand.ToLower()))
            {
                return this.Cars.Where(car => car.Brand == brand.ToLower()).Select(car => car.Price).Average();
            }
            else
            {
                throw new Exception("Brand does not found");
            }
        }
    }
}
