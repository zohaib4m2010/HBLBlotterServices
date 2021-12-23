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
    public class scheduler
    {

        private static System.Timers.Timer aTimer;
        private static bool status = Convert.ToBoolean(ConfigurationManager.AppSettings["ShedularTimerStatus"]);
        private static DateTime start = Convert.ToDateTime(ConfigurationManager.AppSettings["ShedularStartTime"]);
        private static DateTime end = Convert.ToDateTime(ConfigurationManager.AppSettings["ShedularEndTime"]);
        private static string Freq = ConfigurationManager.AppSettings["ShedularFreq"];
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
            //aTimer.Dispose();
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
            if (DateTime.Now.ToString("dddd") != "Saturday" || DateTime.Now.ToString("dddd") != "Sunday")
            {
                if (DateTime.Now.ToLocalTime() >= start && DateTime.Now.ToLocalTime() <= end)
                {
                    List<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result> GetSheduler = DAL.GetAllBlotterShedular();
                    if (GetSheduler != null)
                    {
                        if (GetSheduler[0].RegIsUpdated == true)
                        {
                            if (GetSheduler[0].RegIsRun == true)
                            {
                                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Scheduler Started", "");
                                FillRegDumpBlotter.status = Convert.ToBoolean(GetSheduler[0].RegTimerStatus);
                                FillRegDumpBlotter.start = Convert.ToDateTime(GetSheduler[0].RegStartTime);
                                FillRegDumpBlotter.end = Convert.ToDateTime(GetSheduler[0].RegEndTime);
                                FillRegDumpBlotter.Freq = GetSheduler[0].RegFreq;
                                FillRegDumpBlotter.FreqMinutes = Convert.ToInt32(Freq.Split(':')[0]);
                                FillRegDumpBlotter.FreqSeconds = FreqSeconds = Convert.ToInt32(Freq.Split(':')[1]);
                                FillRegDumpBlotter.Start();
                            }
                            else
                            {
                                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Scheduler Ended", "");

                                if (FillRegDumpBlotter.RegTimer != null)
                                {
                                    if (FillRegDumpBlotter.RegTimer.Enabled)
                                        FillRegDumpBlotter.Stop();
                                }
                            }
                            Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Scheduler Updated", "");
                            DAL.IsUpdateSheduler(1);
                        }
                        else
                        {
                            if (GetSheduler[0].RegIsRun == true)
                            {
                                if (!FillRegDumpBlotter.RegTimer.Enabled)
                                    FillRegDumpBlotter.Start();
                            }
                        }
                        if (GetSheduler[0].FwdIsUpdated == true)
                        {
                            if (GetSheduler[0].FwdIsRun == true)
                            {
                                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd Scheduler Started", "");
                                FillFwdDumpBlotter.status = Convert.ToBoolean(GetSheduler[0].FwdTimerStatus);
                                FillFwdDumpBlotter.start = Convert.ToDateTime(GetSheduler[0].FwdStartTime);
                                FillFwdDumpBlotter.end = Convert.ToDateTime(GetSheduler[0].FwdEndTime);
                                FillFwdDumpBlotter.Freq = GetSheduler[0].FwdFreq;
                                FillFwdDumpBlotter.FreqMinutes = Convert.ToInt32(Freq.Split(':')[0]);
                                FillFwdDumpBlotter.FreqSeconds = FreqSeconds = Convert.ToInt32(Freq.Split(':')[1]);
                                FillFwdDumpBlotter.Start();
                            }
                            else
                            {
                                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd Scheduler Ended", "");

                                if (FillFwdDumpBlotter.FwdTimer != null)
                                {
                                    if (FillFwdDumpBlotter.FwdTimer.Enabled)
                                        FillFwdDumpBlotter.Stop();
                                }
                            }
                            Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd Scheduler Updated", "");
                            DAL.IsUpdateSheduler(2);
                        }
                        else
                        {
                            if (FillFwdDumpBlotter.FwdTimer != null)
                            {
                                if (!FillFwdDumpBlotter.FwdTimer.Enabled)
                                    FillFwdDumpBlotter.Start();
                            }
                        }
                    }
                }
                else
                {

                    if (FillRegDumpBlotter.RegTimer != null)
                    {
                        if (FillRegDumpBlotter.RegTimer.Enabled)
                            FillRegDumpBlotter.Stop();
                    }

                    if (FillFwdDumpBlotter.FwdTimer != null)
                    {
                        if (FillFwdDumpBlotter.FwdTimer.Enabled)
                            FillFwdDumpBlotter.Stop();
                    }
                }
            }
        }

    }
}