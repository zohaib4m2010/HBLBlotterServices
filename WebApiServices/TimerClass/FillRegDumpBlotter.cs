using Quartz;
using Quartz.Impl;
using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiServices.TimerClass
{
    public class FillRegDumpBlotter
    {

        public static bool status = false;
        public static DateTime start;
        public static DateTime end;
        public static string Freq;
        public static int FreqMinutes;
        public static int FreqSeconds;
        public static void Start()
        {
            if (!status)
            {
                status = true;
                SetTimer();
            }
        }

        private static async Task SetTimer()
        {
            try
            {
                int FreqInSec = 0;

                if (FreqMinutes > 0)
                    FreqInSec = 60 * FreqMinutes;
                else
                    if (FreqSeconds > 0)
                    FreqInSec = FreqSeconds;
                else
                    FreqInSec = 60 * 60;


                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<RegScheduleJob>()
                    .WithIdentity("RegScheduleJob", "RegScheduleGroup")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("RegScheduleTrigger", "RegScheduleGroup")
                    .StartNow()
                    .WithDailyTimeIntervalSchedule(x => x
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(start.Hour, start.Minute))
                    .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(end.Hour, end.Minute))
                    .WithIntervalInSeconds(FreqInSec)
                    .OnMondayThroughFriday()
                    .OnEveryDay())
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ischeduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {
            }
        }
        private class RegScheduleJob : IJob
        {
            public async Task Execute(IJobExecutionContext context)
            {
                Utilities.WriteLogs(MethodBase.GetCurrentMethod().Name, "Reg Job Runing", "");
                Utilities.FillRegDumBlotterBR1();
                Utilities.FillRegDumBlotterBR2();
            }
        }
    }
}