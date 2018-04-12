using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    /// <summary>
    /// Class listener
    /// </summary>
    public class MessangerListener
    {
        /// <summary>
        /// Handler event end timer
        /// </summary>
        /// <param name="sender">information about object who send event</param>
        /// <param name="e">information about event</param>
        public void OnAlarmRing_Handler(object sender, AlarmInfoEventArgs e)
        {
            Console.WriteLine($"Call Messanger : set time {e.Hours} : {e.Minutes} : {e.Seconds} expired.");
        }
    }
}
