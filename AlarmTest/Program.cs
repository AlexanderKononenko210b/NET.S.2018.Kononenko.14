using System;
using AlarmClock;

namespace AlarmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarmClock = new Alarm(0, 0, 10);

            FaxListener fax = new FaxListener();

            alarmClock.AlarmRing += fax.OnAlarmRing_Handler;

            MessangerListener messanger = new MessangerListener();

            alarmClock.AlarmRing += messanger.OnAlarmRing_Handler;

            alarmClock.AlarmStart();

            Console.ReadLine();
        }
    }
}
