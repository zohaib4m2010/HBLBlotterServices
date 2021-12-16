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
    public class FillFwdDumpBlotter
    {
        public static System.Timers.Timer FwdTimer = new Timer();
        public static bool status;
        public static DateTime start;
        public static DateTime end;
        public static string Freq;
        public static int FreqMinutes;
        public static int FreqSeconds;
        public static void Start()
        {

            //DAL.TESTRECONTEST("Start Before STatus");
            if (status)
            {
                try
                {
                    //DAL.TESTRECONTEST("Start after Status");
                    SetTimer();
                    FwdTimer.Start();
                }
                catch (Exception ex)
                {
                    //DAL.TESTRECONTEST(ex.Message.ToString());
                    //.TESTRECONTEST(ex.InnerException.ToString());
                }
            }
        }
        public static void Stop()
        {
            FwdTimer.Stop();
            FwdTimer.Dispose();
        }
        private static void SetTimer()
        {
            try
            {
                //DAL.TESTRECONTEST("SetTimer");
                // Create a timer with a two second interval.
                FwdTimer = new System.Timers.Timer();
                // Hook up the Elapsed event for the timer. 
                FwdTimer.Elapsed += OnTimedEvent;
                if (FreqMinutes > 0)
                    FwdTimer.Interval = 1000 * 60 * FreqMinutes;
                else
                    if (FreqSeconds > 0)
                    FwdTimer.Interval = 1000 * FreqSeconds;
                else
                    FwdTimer.Interval = 1000 * 60 * 60;
                FwdTimer.AutoReset = true;
                FwdTimer.Enabled = true;

            }
            catch (Exception ex)
            {
                //DAL.TESTRECONTEST(ex.Message.ToString());
                //DAL.TESTRECONTEST(ex.InnerException.ToString());
            }
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //DAL.TESTRECONTEST("OnTimedEvent");
            if (DateTime.Now.ToLocalTime() >= start && DateTime.Now.ToLocalTime() <= end)
            {
                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd Dump Started", "");
                //DAL.TESTRECONTEST("OnTimedEvent if condition true");
                DAL.FillFwdDumBlotterBR1();
                DAL.FillFwdDumBlotterBR2();
            }
            else
            {
                FwdTimer.Stop();
                FwdTimer.Dispose();
                //DAL.TESTRECONTEST("OnTimedEvent if condition false");
            }
        }
    }
}