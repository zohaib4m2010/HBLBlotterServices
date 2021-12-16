using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApiServices.Classes;
using WebApiServices.Models;

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


        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static string GetBlotterLogin(String userName, String password)
        {
            string results = null;
            try
            {
                nv.Clear();
                nv.Add("@UserName-varchar", userName);
                nv.Add("@Password-varchar", password);
                results = JsonConvert.SerializeObject(dall.GetData("SP_SBPGetLoginInfo", nv).Tables[0]); 
            }
            catch (Exception ex)
            {
                WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static string GetBlotterLoginById(int id)
        {
            string results = null;
            try
            {
                nv.Clear();
                nv.Add("@id-int", id.ToString());
                results = JsonConvert.SerializeObject(dall.GetData("SP_SBPGetLoginInfoById", nv).Tables[0]);
            }
            catch (Exception ex)
            {
                WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static void SessionStart(string pSessionID, int pUserID, string pIP, string pLoginGUID, Nullable<DateTime> pLoginTime, Nullable<DateTime> pExpires)
        {
            string results = null;
            try
            {
                nv.Clear();
                nv.Add("@pSessionID-varchar", pSessionID);
                nv.Add("@pUserID-int", pUserID.ToString());
                nv.Add("@pIP-int", pIP);
                nv.Add("@pLoginTime-datetime", pLoginTime.ToString());
                nv.Add("@pExpires-datetime", pExpires.ToString());
                results = JsonConvert.SerializeObject(dall.GetData("SP_ADD_SessionStart", nv).Tables[0]);
            }
            catch (Exception ex)
            {
                WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }

        }
        //public static void ActivityMonitor(string pSessionID, int pUserID, string pIP, string pLoginGUID, string Data, string Activity, string URL)
        //{
        //    try
        //    {
        //        DbContextB.SP_ADD_ActivityMonitor(pSessionID, pUserID, pIP, pLoginGUID, Data, Activity, URL);
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
        //    }
        //}

        //public static void SessionStop(string pSessionID, int pUserID)
        //{
        //    try
        //    {
        //        DbContextB.SP_SBPSessionStop(pSessionID, pUserID);
        //    }
        //    catch (Exception ex)
        //    {
        //        DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
        //    }
        //}
    }
}