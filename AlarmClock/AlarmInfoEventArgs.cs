using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AlarmClock
{
    /// <summary>
    /// Class for information about event
    /// </summary>
    public sealed class AlarmInfoEventArgs : EventArgs
    {
        private readonly int hours;

        private readonly int minutes;

        private readonly int seconds;

        public AlarmInfoEventArgs(int hour, int minute, int second)
        {
            this.hours = hour;
            this.minutes = minute;
            this.seconds = second;
        }

        public int Hours => hours;

        public int Minutes => minutes;

        public int Seconds => seconds;
    }
}
