﻿using System;

namespace DevTask6
{
    /// <summary>
    /// Class for counting cars method
    /// </summary>
    class CountAllCommand : ICommand
    {
        private CarCatalog Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCatalog">Catalog of cars</param>
        public CountAllCommand(CarCatalog carCatalog)
        {
            this.Catalog = carCatalog;
        }

        /// <summary>
        /// Calls method for catalog of cars and display count of cars
        /// </summary>
        public void Execute()
        {
            Console.WriteLine(Catalog?.GetCarsCount());
        }
    }
}
