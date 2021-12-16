using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApiServices.Classes;

namespace WebApiServices.TimerClass
{
    public class Utilities
    {
        private static NameValueCollection nv = new NameValueCollection();
        private static DALL dall = new DALL();
        private static string fileLocation = ConfigurationManager.AppSettings["LogFileLocation"];
        public static void WriteLogs(string method, string message, string innermessage)
        {
            try
            {
                if (!Directory.Exists(fileLocation))
                {
                    Directory.CreateDirectory(fileLocation);
                }
                //Pass the filepath and filename to the StreamWriter Constructor
                using (StreamWriter sw = new StreamWriter((fileLocation + "\\Logs_" + DateTime.Now.ToString("yyyyyddMM") + ".txt"), append: true))
                {
                    sw.WriteLine("Method | " + method);
                    sw.WriteLine("Time | " + DateTime.Now.ToString("HH:mm:ss"));
                    sw.WriteLine("Message | " + message);
                    sw.WriteLine("InnerMessage | " + innermessage);
                    sw.WriteLine("=========================================================================================================================================================================================");
                    //Close the file
                    sw.Close();
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
            }
        }

        //*****************************************************
        //Fill Reg Dump Blotter Producers
        //*****************************************************
        public static void FillRegDumBlotterBR1()
        {
            try
            {
                nv.Clear();
                nv.Add("@BR-int","1");
                nv.Add("@Date-datetime", DateTime.Now.ToString());
                dall.GetData("SP_ReconcileOPICSManualData",nv);
            }
            catch (Exception ex)
            {
                WriteLogs("Utilities" + " - " + MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        public static void FillRegDumBlotterBR2()
        {
            try
            {
                nv.Clear();
                nv.Add("@BR-int", "2");
                nv.Add("@Date-datetime", DateTime.Now.ToString());
                dall.GetData("SP_ReconcileOPICSManualData", nv);
            }
            catch (Exception ex)
            {
                WriteLogs("Utilities" + " - " + MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        //*****************************************************
        //Fill Forward Dump Blotter Producers
        //*****************************************************

        public static void FillFwdDumBlotterBR1()
        {
            try
            {
                nv.Clear();
                nv.Add("@BR-int", "1");
                nv.Add("@Date-datetime", DateTime.Now.ToString());
                nv.Add("@FillDumpBlotter-bit", "1");
                dall.GetData("SP_ReconcileOPICSManualDataFwd", nv);
            }
            catch (Exception ex)
            {
                WriteLogs("Utilities" + " - " + MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        public static void FillFwdDumBlotterBR2()
        {
            try
            {
                nv.Clear();
                nv.Add("@BR-int", "2");
                nv.Add("@Date-datetime", DateTime.Now.ToString());
                nv.Add("@FillDumpBlotter-bit", "1");
                dall.GetData("SP_ReconcileOPICSManualDataFwd", nv);
            }
            catch (Exception ex)
            {
                WriteLogs("Utilities" + " - " + MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }


        public static void SP_TemporyLoop()
        {
            try
            {
                dall.GetData("SP_TemporyLoop", null);
            }
            catch (Exception ex)
            {
                WriteLogs("Utilities" + " - " + MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
    }
}