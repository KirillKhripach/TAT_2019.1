namespace ClassWork9
{
    /// <summary>
    /// Class for choosing writer
    /// </summary>
    public class Writer
    {
        private const string _jsonFormat = "json";
        private const string _xmlFormat = "xml";

        /// <summary>
        /// Returns writer creator according to input data
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <returns>Writer</returns>
        public IWriter GetWriter(string fileName)
        {
            int startIndex = fileName.IndexOf('.');
            string format = fileName.Substring(startIndex + 1);

            switch (format.ToLower())
            {
                case _jsonFormat:
                    return new JsonWriter(fileName);
                case _xmlFormat:
                    return new XmlWriter(fileName);
                default:
                    return null;
            }
        }
    }
}
