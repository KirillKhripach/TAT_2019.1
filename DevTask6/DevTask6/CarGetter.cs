using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace DevTask6
{
    /// <summary>
    /// Class for parsing xml file
    /// </summary>
    class CarGetter
    {
        private XDocument XDoc { get; set; }

        /// <summary>
        /// Constructor allocates memory
        /// </summary>
        public CarGetter()
        {
            XDoc = new XDocument();
        }

        /// <summary>
        /// Loads xml file and gets cars from it
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Collection of cars</returns>
        public IEnumerable<Car> GetCars(string fileName)
        {
            XDoc = XDocument.Load($"../../{fileName}.xml");

            IEnumerable<Car> cars = XDoc.Element("cars").Elements("car").Select(xe => new Car
            (
                xe.Element("brand").Value,
                xe.Element("model").Value,
                int.TryParse(xe.Element("count").Value, out int count) ? count : throw new Exception("Incorrect count value"),
                int.TryParse(xe.Element("price").Value, out int price) ? price : throw new Exception("Incorrect price value")
             ));

            return cars;
        }
    }
}
