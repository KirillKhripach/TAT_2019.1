using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassWork9
{
    /// <summary>
    /// Class for writing to json file
    /// </summary>
    public class JsonWriter : IWriter
    {
        private readonly string _filePath;

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public JsonWriter(string fileName)
        {
            this._filePath = $"../../{fileName}";
        }

        /// <summary>
        /// Writes list to the json file
        /// </summary>
        /// <param name="currencies">List of currencies</param>
        public void Write(List<Currency> currencies)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Currency>));

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, currencies);
            }
        }
    }
}
