using System.Collections.Generic;

namespace ClassWork9
{
    /// <summary>
    /// Interface for factory pattern
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Writes list to the file
        /// </summary>
        /// <param name="currencies">List of currencies</param>
        void Write(List<Currency> currencies);
    }
}
