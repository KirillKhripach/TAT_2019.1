using System;
using System.Collections.Generic;
using System.Xml;

namespace DevTask6
{
    /// <summary>
    /// Class for parsing xml file
    /// </summary>
    class CarGetter
    {
        private XmlDocument XmlDoc { get; set; }

        /// <summary>
        /// Constructor loads xml file
        /// </summary>
        /// <param name="fileName">File name</param>
        public CarGetter(string fileName)
        {
            XmlDoc = new XmlDocument();
            XmlDoc.Load($"../../{fileName}.xml");
        }

        /// <summary>
        /// Gets cars from xml file
        /// </summary>
        /// <returns>List of cars</returns>
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            XmlElement xmlElement = XmlDoc.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                string brand = string.Empty;
                string model = string.Empty;
                int count = 0;
                int price = 0;

                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "brand":
                            brand = childNode.InnerText;
                            break;

                        case "model":
                            model = childNode.InnerText;
                            break;

                        case "count":
                            if (!int.TryParse(childNode.InnerText, out count))
                            {
                                throw new Exception("Incorrect count value");
                            }
                            break;

                        case "price":
                            if (!int.TryParse(childNode.InnerText, out price))
                            {
                                throw new Exception("Incorrect price value");
                            }
                            break;

                        default:
                            break;
                    }
                }

                cars.Add(new Car(brand, model, count, price));
            }

            return cars;
        }
    }
}
