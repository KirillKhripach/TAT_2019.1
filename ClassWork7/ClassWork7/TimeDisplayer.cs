using System;

namespace ClassWork7
{
    /// <summary>
    /// Class for displaying time span
    /// </summary>
    class TimeDisplayer
    {
        /// <summary>
        /// Displayes minutes, seconds, milliseconds of time span
        /// </summary>
        /// <param name="timeSpan">Time span</param>
        public void DisplayTime(TimeSpan timeSpan)
        {
            Console.WriteLine($"Time span {timeSpan.Minutes:0} minutes {timeSpan.Seconds:0} seconds {timeSpan.Milliseconds:0} milliseconds");
        }
    }
}
