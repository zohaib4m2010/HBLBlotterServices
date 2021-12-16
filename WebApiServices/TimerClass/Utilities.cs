using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApiServices.TimerClass
{
    public class Utilities
    {
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
    }
}