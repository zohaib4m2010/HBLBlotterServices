using DataAccessLayer;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace WebApiServices.TimerClass
{
    public class scheduler
    {

        private static bool status = Convert.ToBoolean(ConfigurationManager.AppSettings["ShedularTimerStatus"]);
        private static DateTime start= Convert.ToDateTime(ConfigurationManager.AppSettings["ShedularStartTime"]);
        private static DateTime end = Convert.ToDateTime(ConfigurationManager.AppSettings["ShedularEndTime"]);
        private static string Freq = ConfigurationManager.AppSettings["ShedularFreq"];
        private static int FreqMinutes = Convert.ToInt32(Freq.Split(':')[0]);
        private static int FreqSeconds = Convert.ToInt32(Freq.Split(':')[1]);
        public static IScheduler ischeduler = null;

        // Grab the Scheduler instance from the Factory
        private static StdSchedulerFactory factory = new StdSchedulerFactory();


        public static void Start()
        {
            if (status)
            {
                SetTimer();
            }
        }
        public static void Stop()
        {
            Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Job Scheduler Shutdown", "");
            ischeduler.Shutdown();
            ischeduler.Clear();
            FillRegDumpBlotter.status = false;
            FillFwdDumpBlotter.status = false;
        }
        private static async Task SetTimer()
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            ischeduler = await factory.GetScheduler();

            // and start it off
            await ischeduler.Start();
            int FreqInSec = 0;

            if (FreqMinutes > 0)
                FreqInSec = 60 * FreqMinutes;
            else
                if (FreqSeconds > 0)
                FreqInSec = FreqSeconds;
            else
                FreqInSec = 60 * 60;


            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<ScheduleJob>()
                .WithIdentity("ScheduleJob", "ScheduleGroup")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ScheduleTrigger", "ScheduleGroup")
                .StartNow()
                    .WithDailyTimeIntervalSchedule(x => x
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(start.Hour,start.Minute))
                    .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(end.Hour, end.Minute))
                    .WithIntervalInSeconds(FreqInSec)   
                    .OnMondayThroughFriday()
                    .OnEveryDay())
                .Build();

            // Tell quartz to schedule the job using our trigger
            await ischeduler.ScheduleJob(job, trigger);
        }

        private class ScheduleJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Job Scheduler Runing - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "");
                try
                {
                    //Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Try", "");
                    List<DataAccessLayer.SP_GetSBPBlotterGetSheduler_Result> GetSheduler = DAL.GetAllBlotterShedular();
                    if (GetSheduler != null)
                    {
                       // Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "GetSheduler", "");
                        if (GetSheduler[0].RegIsUpdated == true)
                        {
                            Stop();
                            Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Scheduler Updated", "");
                            DAL.IsUpdateSheduler(1);
                            DAL.IsUpdateSheduler(2);
                            Start();
                        }
                        else if (GetSheduler[0].FwdIsUpdated == true)
                        {

                            Stop();
                            Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd Scheduler Updated", "");
                            DAL.IsUpdateSheduler(1);
                            DAL.IsUpdateSheduler(2);
                            Start();
                        }
                        else
                        {
                            if (GetSheduler[0].RegIsRun == true)
                            {
                                //Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "RegIsRun", "");
                                if (!FillRegDumpBlotter.status)
                                {
                                   // Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg status", "");
                                    FillRegDumpBlotter.start = Convert.ToDateTime(GetSheduler[0].RegStartTime);
                                    FillRegDumpBlotter.end = Convert.ToDateTime(GetSheduler[0].RegEndTime);
                                    FillRegDumpBlotter.Freq = GetSheduler[0].RegFreq;
                                    FillRegDumpBlotter.FreqMinutes = Convert.ToInt32(FillRegDumpBlotter.Freq.Split(':')[0]);
                                    FillRegDumpBlotter.FreqSeconds = Convert.ToInt32(FillRegDumpBlotter.Freq.Split(':')[1]);
                                    FillRegDumpBlotter.Start();
                                }
                            }
                            if (GetSheduler[0].FwdIsRun == true)
                            {
                                //Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "FwdIsRun", "");
                                if (!FillFwdDumpBlotter.status)
                                {
                                    //Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Fwd status", "");
                                    FillFwdDumpBlotter.start = Convert.ToDateTime(GetSheduler[0].FwdStartTime);
                                    FillFwdDumpBlotter.end = Convert.ToDateTime(GetSheduler[0].FwdEndTime);
                                    FillFwdDumpBlotter.Freq = GetSheduler[0].FwdFreq;
                                    FillFwdDumpBlotter.FreqMinutes = Convert.ToInt32(FillFwdDumpBlotter.Freq.Split(':')[0]);
                                    FillFwdDumpBlotter.FreqSeconds = Convert.ToInt32(FillFwdDumpBlotter.Freq.Split(':')[1]);
                                    FillFwdDumpBlotter.Start();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
                }
            }
        }


        // simple log provider to get something to the console
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        //Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);

                        Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Job Scheduler Log-", level + func());
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }
}