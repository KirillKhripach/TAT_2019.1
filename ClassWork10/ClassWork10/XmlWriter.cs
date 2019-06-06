using System.IO;
using System.Xml.Serialization;

namespace ClassWork10
{
    class XmlWriter
    {
        private readonly string _filePath;

        public XmlWriter(string fileName)
        {
            this._filePath = $"../../{fileName}";
        }
        
        public void Write(object obj, TimeReadEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TimeViewer));

            using (FileStream fs = new FileStream(this._filePath, FileMode.Append))
            {
                xmlSerializer.Serialize(fs, e.TimeViewer);
            }
        }
    }
}
