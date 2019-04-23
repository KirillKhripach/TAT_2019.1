using System;

namespace DevTask6
{
    /// <summary>
    /// Class for cars
    /// </summary>
    class Car
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }

        /// <summary>
        /// Constructor initializes properties and validates input data
        /// </summary>
        /// <param name="brand">Brand of the car</param>
        /// <param name="model">Model of the car</param>
        /// <param name="count">Count of cars</param>
        /// <param name="price">Price of one car</param>
        public Car(string brand, string model, int count, int price)
        {
            this.Brand = brand != string.Empty ? brand.ToLower() : throw new Exception("Brand should not be empty");
            this.Model = model != string.Empty ? model.ToLower() : throw new Exception("Model should not be empty");
            this.Count = count >= 0 ? count : throw new Exception("Count should be non-negative");
            this.Price = price >= 0 ? price : throw new Exception("Price should be non-negative");
        }
    }
}
