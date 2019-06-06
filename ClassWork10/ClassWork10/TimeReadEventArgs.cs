using System;

namespace ClassWork10
{
    class TimeReadEventArgs : EventArgs
    {
        public TimeViewer TimeViewer { get; private set; }

        public TimeReadEventArgs(TimeViewer timeViewer)
        {
            this.TimeViewer = timeViewer;
        }
    }
}
