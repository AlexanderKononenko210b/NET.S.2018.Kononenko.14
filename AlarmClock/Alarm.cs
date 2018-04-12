using System;
using System.Timers;


namespace AlarmClock
{
    /// <summary>
    /// Class inform subscribers about stop timer
    /// </summary>
    public class Alarm
    {
        private const int COUNT_SECONDS_IN_HOUR = 3600;

        private const int COUNT_SECONDS_IN_MINUT = 60;

        private DateTime newDateTime;

        private Timer timer = new Timer(1000);

        private readonly AlarmInfoEventArgs eventInfo;

        public event EventHandler<AlarmInfoEventArgs> AlarmRing = delegate { };

        /// <summary>
        /// Constructor class Alarm
        /// </summary>
        /// <param name="hour">hours</param>
        /// <param name="minute">minute</param>
        /// <param name="second">second</param>
        public Alarm(int hour, int minute, int second)
        {
            this.eventInfo = new AlarmInfoEventArgs(hour, minute, second);
        }

        /// <summary>
        /// Handler for check time when work timer
        /// </summary>
        /// <param name="sender">object - timer</param>
        /// <param name="e">information about event</param>
        private void OnCheckTime_Handler(object sender, EventArgs e)
        {
            Console.WriteLine($"1 second");

            if ((newDateTime - DateTime.Now) < TimeSpan.Zero)
            {
                OnAlarmRing(this.eventInfo);
            }
        }

        /// <summary>
        /// Method for call event with object information and information about event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnAlarmRing(AlarmInfoEventArgs e)
        {
            AlarmRing(this, e);

            timer.Stop();
        }

        /// <summary>
        /// Method for initial timer
        /// </summary>
        public void AlarmStart()
        {
            this.newDateTime = DateTime.Now.AddSeconds(eventInfo.Hours * COUNT_SECONDS_IN_HOUR + eventInfo.Minutes * COUNT_SECONDS_IN_MINUT + eventInfo.Seconds);

            Console.WriteLine($"newDateTime: {newDateTime} - DateTime: {DateTime.Now}");

            timer.Elapsed += OnCheckTime_Handler;

            timer.Start();
        }
    }
}
