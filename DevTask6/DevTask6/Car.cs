using System;

namespace DevTask6
{
    /// <summary>
    /// Class for cars
    /// </summary>
    class Car
    {
        private string _brand;
        private string _model;
        private int _count;
        private int _price;

        public string Brand
        {
            get => this._brand;
            private set => this._brand = value != string.Empty ? value.ToLower() : throw new Exception("Brand should not be empty");
        }

        public string Model
        {
            get => this._model;
            private set => this._model = value != string.Empty ? value.ToLower() : throw new Exception("Model should not be empty");
        }

        public int Count
        {
            get => this._count;
            private set => this._count = value >= 0 ? value : throw new Exception("Count should be non-negative");
        }

        public int Price
        {
            get => this._price;
            private set => this._price = value >= 0 ? value : throw new Exception("Price should be non-negative");
        }


        /// <summary>
        /// Constructor initializes properties and validates input data
        /// </summary>
        /// <param name="brand">Brand of the car</param>
        /// <param name="model">Model of the car</param>
        /// <param name="count">Count of cars</param>
        /// <param name="price">Price of one car</param>
        public Car(string brand, string model, int count, int price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Count = count;
            this.Price = price;
        }
    }
}
