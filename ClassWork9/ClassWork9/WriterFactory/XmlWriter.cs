using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassWork9
{
    /// <summary>
    /// Class for writing to xml file
    /// </summary>
    public class XmlWriter : IWriter
    {
        private readonly string _filePath;

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public XmlWriter(string fileName)
        {
            this._filePath = $"../../{fileName}";
        }

        /// <summary>
        /// Writes list to the xml file
        /// </summary>
        /// <param name="currencies">List of currencies</param>
        public void Write(List<Currency> currencies)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Currency>));

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, currencies);
            }
        }
    }
}
