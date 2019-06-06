using System;
using System.Runtime.Serialization;

namespace ClassWork10
{
    [Serializable]
    [DataContract]
    public class TimeViewer
    {
        [DataMember]
        public int Hours { get; set; }
        [DataMember]
        public int Minutes { get; set; }
        [DataMember]
        public int Seconds { get; set; }

        public TimeViewer() { }

        public TimeViewer(TimeSpan timeSpan)
        {
            this.Hours = timeSpan.Hours;
            this.Minutes = timeSpan.Minutes;
            this.Seconds = timeSpan.Seconds;
        }
    }
}
