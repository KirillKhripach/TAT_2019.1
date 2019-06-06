using System;
using System.Threading;

namespace ClassWork10
{
    class TimeController
    {
        public event EventHandler<TimeReadEventArgs> TimeRead;

        public void StartTimeReading()
        {
            Random random = new Random();

            while (true)
            {
                Thread.Sleep(random.Next(5000));
                TimeRead?.Invoke(this, new TimeReadEventArgs(new TimeViewer(DateTime.Now.TimeOfDay)));
                Console.WriteLine("Time read");
            }
        }
    }
}
