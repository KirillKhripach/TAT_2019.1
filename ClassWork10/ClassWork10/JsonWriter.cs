using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassWork10
{
    class JsonWriter
    {
        private readonly string _filePath;
        
        public JsonWriter(string fileName)
        {
            this._filePath = $"../../{fileName}";
        }
        
        public void Write(object obj, TimeReadEventArgs e)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TimeViewer));

            using (FileStream fs = new FileStream(this._filePath, FileMode.Append))
            {
                jsonFormatter.WriteObject(fs, e.TimeViewer);
            }
        }
    }
}
