using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using System.Web;

namespace WebApiServices.TimerClass
{
    public class FillRegDumpBlotter
    {

        private static System.Timers.Timer aTimer;
        private static bool status = Convert.ToBoolean(ConfigurationManager.AppSettings["RegTimerStatus"]);
        private static DateTime start = Convert.ToDateTime(ConfigurationManager.AppSettings["RegStartTime"]);
        private static DateTime end = Convert.ToDateTime(ConfigurationManager.AppSettings["RegEndTime"]);
        private static string Freq = ConfigurationManager.AppSettings["RegFreq"];
        private static int FreqMinutes = Convert.ToInt32(Freq.Split(':')[0]);
        private static int FreqSeconds = Convert.ToInt32(Freq.Split(':')[1]);
        public static void Start()
        {
            if (status)
            {
                SetTimer();
                aTimer.Start();
            }
        }
        public static void Stop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer();
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            if (FreqMinutes > 0)
                aTimer.Interval = 1000 * 60 * FreqMinutes;
            else
                if (FreqSeconds > 0)
                aTimer.Interval = 1000 * FreqSeconds;
            else
                aTimer.Interval = 1000 * 60 * 60;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.ToLocalTime() >= start && DateTime.Now.ToLocalTime() <= end)
            {
                DAL.FillRegDumBlotterBR1();
                DAL.FillRegDumBlotterBR2();
            }
        }
    }
}