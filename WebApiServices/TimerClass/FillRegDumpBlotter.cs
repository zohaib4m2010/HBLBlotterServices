using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Web;

namespace WebApiServices.TimerClass
{
    public class FillRegDumpBlotter
    {

        public static System.Timers.Timer RegTimer = new Timer();
        public static bool status;
        public static DateTime start;
        public static DateTime end;
        public static string Freq;
        public static int FreqMinutes;
        public static int FreqSeconds;
        public static void Start()
        {
            if (status)
            {
                SetTimer();
                RegTimer.Start();
            }
        }
        public static void Stop()
        {
            RegTimer.Stop();
            RegTimer.Dispose();
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            RegTimer = new System.Timers.Timer();
            // Hook up the Elapsed event for the timer. 
            RegTimer.Elapsed += OnTimedEvent;
            if (FreqMinutes > 0)
                RegTimer.Interval = 1000 * 60 * FreqMinutes;
            else
                if (FreqSeconds > 0)
                RegTimer.Interval = 1000 * FreqSeconds;
            else
                RegTimer.Interval = 1000 * 60 * 60;
            RegTimer.AutoReset = true;
            RegTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.ToLocalTime() >= start && DateTime.Now.ToLocalTime() <= end)
            {
                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Dump Started", "");
                Utilities.FillRegDumBlotterBR1();
                Utilities.FillRegDumBlotterBR2();
            }
            else
            {
                if (RegTimer.Enabled)
                {
                    RegTimer.Stop();
                    RegTimer.Dispose();
                }

            }
        }
    }
}