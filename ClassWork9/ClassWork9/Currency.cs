using System;
using System.Runtime.Serialization;

namespace ClassWork9
{
    /// <summary>
    /// Class for describing currencies
    /// </summary>
    [Serializable]
    [DataContract]
    public class Currency
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ExchangeRate { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Currency() { }
            
        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="Name">Name of the currency</param>
        /// <param name="exchangeRate">Exchange rate of the currency</param>
        public Currency(string Name, string exchangeRate)
        {
            this.Name = Name;
            this.ExchangeRate = exchangeRate;
        }
    }
}
