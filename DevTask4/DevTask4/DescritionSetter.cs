using System;
using System.Collections.Generic;

namespace DevTask4
{
    /// <summary>
    /// Class for description set
    /// </summary>
    class DescriptionSetter
    {
        private static List<string> descriptions = new List<string>() { "boring", "interesting", "strange" };

        /// <summary>
        /// Generates random string description
        /// </summary>
        /// <returns>String description</returns>
        public string SetDescription()
        {
            Random random = new Random();
            return $"Something {descriptions[random.Next(descriptions.Count)]}";
        }
    }
}
