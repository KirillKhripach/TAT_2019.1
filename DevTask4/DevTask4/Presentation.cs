using System;
using System.Collections.Generic;

namespace DevTask4
{
    /// <summary>
    /// Class for presentations
    /// </summary>
    class Presentation
    {
        public string URI { get; private set; }
        public PresentationFormat Format { get; private set; }
        private static List<string> uris = new List<string>() { "maths", "physics", "English" };

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Presentation()
        {
            Random random = new Random();
            URI = $"wikipedia.org/wiki/presentations/{uris[random.Next(uris.Count)]}";
            Format = (PresentationFormat)random.Next(Enum.GetNames(typeof(PresentationFormat)).Length);
        }

        /// <summary>
        /// Сopy constructor
        /// </summary>
        /// <param name="URI">URI</param>
        /// <param name="Format">Format</param>
        public Presentation(string URI, PresentationFormat Format)
        {
            this.URI = URI;
            this.Format = Format;
        }
    }
}
