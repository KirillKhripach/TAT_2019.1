using System;

namespace ClassWork10
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                TimeController timeController = new TimeController();
                timeController.TimeRead += new JsonWriter("wtf.json").Write;
                timeController.TimeRead += new XmlWriter("wtf.xml").Write;
                timeController.StartTimeReading();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
