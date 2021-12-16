using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {

        static BlotterEntity DbContextB;
        static DAL()
        {

            DbContextB = new BlotterEntity();

        }
        private static string fileLocation = ConfigurationManager.AppSettings.Get("DALLogFileLocation");
        private static void WriteLogs(string method, string message, string innermessage)
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

        public static List<SP_SBPBlotter_Result> GetAllBlotterData(String Br, String DataType, String CurrentDate, bool LoadData)
        {
            List<SP_SBPBlotter_Result> results = null;
            try
            {
                if (LoadData)
                    DbContextB.SP_SBPFillDumBlotter(Convert.ToDateTime(CurrentDate), Convert.ToInt32(Br));
                results = DbContextB.SP_SBPBlotter(Br, DataType, Convert.ToDateTime(CurrentDate)).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GETLatestBlotterDTLReportDayWise_Result> GetLatestBlotterDTLDayWise(int BR, string StartDate, string EndDate)
        {
            List<SP_GETLatestBlotterDTLReportDayWise_Result> results = null;
            try
            {
                results = DbContextB.SP_GETLatestBlotterDTLReportDayWise(BR, StartDate, EndDate).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GETLatestBlotterDTLPerDayWise_Result> GetLatestBlotterDTLPerDayWise(int BR, string StartDate)
        {
            List<SP_GETLatestBlotterDTLPerDayWise_Result> results = null;
            try
            {
                results = DbContextB.SP_GETLatestBlotterDTLPerDayWise(BR, StartDate).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SP_GETLatestBlotterDTLReportForToday_Result GetLatestBlotterDTLForToday(int BR)
        {
            SP_GETLatestBlotterDTLReportForToday_Result results = null;
            try
            {
                results = DbContextB.SP_GETLatestBlotterDTLReportForToday(BR).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetOPICSManualData_Result> GetOPICSManualData(int BR, DateTime Date, string Flag)
        {
            List<SP_GetOPICSManualData_Result> results = null;
            try
            {
                results = DbContextB.SP_GetOPICSManualData(BR, Date, Flag).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }



        public static SP_GetOpeningBalance_Result GetOpeningBalance(int BR, DateTime Date)
        {
            SP_GetOpeningBalance_Result results = null;
            try
            {
                results = DbContextB.SP_GetOpeningBalance(BR, Date).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_ReconcileOPICSManualData_Result> ReconcileOPICSManualData(int BR, DateTime Date)
        {
            List<SP_ReconcileOPICSManualData_Result> results = null;
            try
            {
                results = DbContextB.SP_ReconcileOPICSManualData(BR, Date).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }


        public static bool UpdateSheduler(BlotterSBP_Sheduler blotterSheduler)
        {
            bool status;
            try
            {
                DbContextB.SP_UpdateBlotterSBP_Sheduler(blotterSheduler.SID, blotterSheduler.RegTimerStatus, blotterSheduler.RegStartTime, blotterSheduler.RegEndTime, blotterSheduler.RegFreq, blotterSheduler.RegIsUpdated, blotterSheduler.RegIsRun, blotterSheduler.FwdTimerStatus, blotterSheduler.FwdStartTime, blotterSheduler.FwdEndTime, blotterSheduler.FwdFreq, blotterSheduler.FwdIsUpdated, blotterSheduler.FwdIsRun);


                status = true;
                //}
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Blotter Projection Producers
        //*****************************************************

        public static List<SP_GetSBP_Projection_Result> GetAllBlotterProjection(int UserID, int BranchID, int BR, string DateVal)
        {
            List<SP_GetSBP_Projection_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBP_Projection(UserID, BranchID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterProjection GetProjectionItem(int projId)
        {
            SBP_BlotterProjection results = null;
            try
            {
                results = DbContextB.SBP_BlotterProjection.Where(p => p.SNO == projId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertProjection(SBP_BlotterProjection ProjItem)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterProjection.Add(ProjItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateProjection(SBP_BlotterProjection ProjItem)
        {
            bool status;
            try
            {
                SBP_BlotterProjection ProjItems = DbContextB.SBP_BlotterProjection.Where(p => p.SNO == ProjItem.SNO).FirstOrDefault();
                if (ProjItems != null)
                {

                    ProjItems.Proj_InFlow = ProjItem.Proj_InFlow;
                    ProjItems.Proj_OutFlow = ProjItem.Proj_OutFlow;

                    ProjItems.Custy = ProjItem.Custy;
                    ProjItems.RSF_NBP = ProjItem.RSF_NBP;

                    ProjItems.Date = ProjItem.Date;
                    ProjItems.Note = ProjItem.Note;
                    ProjItems.UpdateDate = ProjItem.UpdateDate;
                    ProjItems.UserID = ProjItem.UserID;
                    ProjItems.BR = ProjItem.BR;
                    ProjItems.BID = ProjItem.BID;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteProjection(int id)
        {
            bool status;
            try
            {
                SBP_BlotterProjection ProjItem = DbContextB.SBP_BlotterProjection.Where(p => p.SNO == id).FirstOrDefault();
                if (ProjItem != null)
                {
                    DbContextB.SBP_BlotterProjection.Remove(ProjItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //Recon Breakups Producers
        //*****************************************************
        public static List<SP_GETAllRECONBreakupsTransactionTitles_Result> GetAllReconBreakupsTransactionTitles()
        {
            List<SP_GETAllRECONBreakupsTransactionTitles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAllRECONBreakupsTransactionTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterReconBreakups GetRBItem(int id)
        {
            SBP_BlotterReconBreakups results = null;
            try
            {
                results = DbContextB.SBP_BlotterReconBreakups.Where(p => p.SNo == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterReconBreakups_Result> GetAllBlotterReconBreakups(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterReconBreakups_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterReconBreakups(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetAll_SBPBlotterReconBreakups_Dashboard_Result> GetAllBlotterReconBreakupsDashBoard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterReconBreakups_Dashboard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterReconBreakups_Dashboard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertReconBreakups(SBP_BlotterReconBreakups RBItem)
        {
            bool status;
            try
            {

                DbContextB.SP_InsertBlotterReconBreakups(RBItem.DataType, RBItem.TTID, RBItem.RECON_Date, RBItem.RECONCOde, RBItem.RECON_InFlow, RBItem.RECON_OutFLow, RBItem.Note, RBItem.UserID, RBItem.BR, RBItem.BID);
                status = true;

            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        public static bool UpdateReconBreakups(SBP_BlotterReconBreakups RBItem)
        {
            bool status;
            try
            {


                DbContextB.SP_UpdateBlotterReconBreakups(RBItem.SNo, RBItem.DataType, RBItem.TTID, RBItem.RECON_Date, RBItem.RECONCOde, RBItem.RECON_InFlow, RBItem.RECON_OutFLow, RBItem.Note, RBItem.UserID, RBItem.BR, RBItem.BID);
                status = true;

            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        public static bool UpdateReconBreakupByBranchId(SBP_BlotterReconBreakups RBItem)
        {
            bool status;
            try
            {
                DbContextB.SP_UpdateBranchBalanceByBranchId(RBItem.RECON_Date, RBItem.RECON_InFlow, RBItem.RECON_OutFLow, RBItem.UserID, RBItem.BR, RBItem.BID);
                status = true;

            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteReconBreakups(int id)
        {
            bool status;
            try
            {
                SBP_BlotterReconBreakups RbItem = DbContextB.SBP_BlotterReconBreakups.Where(p => p.SNo == id).FirstOrDefault();
                if (RbItem != null)
                {
                    DbContextB.SBP_BlotterReconBreakups.Remove(RbItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //OutRight Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterOutRright_Result> GetAllBlotterOutRight(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetSBPBlotterOutRright_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterOutRright(BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetSBPBlotterOutRrightAuto_Result> GetAllBlotterOutRightAuto(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetSBPBlotterOutRrightAuto_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterOutRrightAuto(BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterOutrights GetSBP_BlotterOutRightById(int OutRightId)
        {
            SBP_BlotterOutrights results = null;
            try
            {
                results = DbContextB.SBP_BlotterOutrights.Where(p => p.SNo == OutRightId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertOutRight(SBP_BlotterOutrights OutRightIdItem)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertBlotterOutright(OutRightIdItem.DataType, OutRightIdItem.Bank, OutRightIdItem.Rate, OutRightIdItem.Issue_Date, OutRightIdItem.IssueType, OutRightIdItem.Broker, OutRightIdItem.InFlow, OutRightIdItem.OutFLow, OutRightIdItem.Date, OutRightIdItem.Note, OutRightIdItem.UserID, OutRightIdItem.BR);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateOutRight(SBP_BlotterOutrights OutRightIdItem)
        {
            bool status;
            try
            {
                DbContextB.SP_UpdateBlotterOutright(OutRightIdItem.SNo, OutRightIdItem.DataType, OutRightIdItem.Bank, OutRightIdItem.Rate, OutRightIdItem.Issue_Date, OutRightIdItem.IssueType, OutRightIdItem.Broker, OutRightIdItem.InFlow, OutRightIdItem.OutFLow, OutRightIdItem.Date, OutRightIdItem.Note, OutRightIdItem.UserID, OutRightIdItem.BR);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteOutRight(int id, int UserId)
        {
            bool status;
            try
            {
                DbContextB.SP_DeleteBlotterOutright(id, UserId);

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Fill Forward Dump Blotter Producers
        //*****************************************************


        public static void SP_TemporyLoop()
        {
            try
            {
                DbContextB.SP_TemporyLoop();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        public static void FillFwdDumBlotterBR1()
        {
            try
            {
                DbContextB.SP_ReconcileOPICSManualDataFwd(1, DateTime.Now, true);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        public static void FillFwdDumBlotterBR2()
        {
            try
            {
                DbContextB.SP_ReconcileOPICSManualDataFwd(2, DateTime.Now, true);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }
        public static void IsUpdateSheduler(int type)
        {
            try
            {
                DbContextB.SP_UpdatedSBPBlotterGetSheduler(type, 1, false);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }

        //*****************************************************
        //GazettedHolidays Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterGH_Result> GetAllBlotterGH()
        {
            List<SP_GetSBPBlotterGH_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterGH(null).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SP_GetSBPBlotterGH_Result GetGHItem(int GHId)
        {
            SP_GetSBPBlotterGH_Result results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterGH(GHId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertGH(string HolidayTitle, string GHDescription, DateTime GHDate, int UserID)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertHolidays(HolidayTitle, GHDescription, GHDate, UserID);
                status = true;
            }
            catch (Exception ex)
            {

                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateGH(int GHID, string HolidayTitle, string GHDescription, DateTime GHDate, int UserID)
        {
            bool status;
            try
            {

                DbContextB.SP_UpdateHolidays(GHID, HolidayTitle, GHDescription, GHDate, UserID);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteGH(int GHID)
        {
            bool status;
            try
            {
                DbContextB.SP_DeleteHolidays(GHID);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //Fill Reg Dump Blotter Producers
        //*****************************************************
        public static void FillRegDumBlotterBR1()
        {
            try
            {
                // DbContextB.SP_SBPFillDumBlotter(DateTime.Now,1);
                DbContextB.SP_ReconcileOPICSManualData(1, DateTime.Now);
            }
            catch (Exception ex)
            {
            }
        }
        public static void FillRegDumBlotterBR2()
        {
            try
            {
                //DbContextB.SP_SBPFillDumBlotter(DateTime.Now, 2);
                DbContextB.SP_ReconcileOPICSManualData(2, DateTime.Now);
            }
            catch (Exception ex)
            {
            }
        }





        //*****************************************************
        //CRRFINCON Producers
        //*****************************************************


        public static List<SP_GetSBPBlotterGetSheduler_Result> GetAllBlotterShedular()
        {

            List<SP_GetSBPBlotterGetSheduler_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterGetSheduler().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static BlotterSBP_Sheduler GetBlotterShedularID(int SID)
        {
            BlotterSBP_Sheduler results = null;
            try
            {
                results = DbContextB.BlotterSBP_Sheduler.Where(p => p.SID == SID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetSBPBlotterCRRFINCON_Result> GetAllBlotterCRRFINCON(int UserID, int BranchID, int CurID, int BR, string StartDate, string EndDate)
        {
            List<SP_GetSBPBlotterCRRFINCON_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterCRRFINCON(UserID, BranchID, CurID, BR, Convert.ToDateTime(StartDate), Convert.ToDateTime(EndDate)).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetCRRFINCONPeriods_Result> GetAllBlotterCRRFINCONPeriods(int BR)
        {
            List<SP_GetCRRFINCONPeriods_Result> results = null;
            try
            {
                results = DbContextB.SP_GetCRRFINCONPeriods(BR).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterCRRFINCON GetCRRFINCONItem(int CRRFINCONId)
        {
            SBP_BlotterCRRFINCON results = null;
            try
            {
                results = DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo == CRRFINCONId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertCRRFINCON(SBP_BlotterCRRFINCON CRRFINCONItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterCRRFINCON> GetCount = DbContextB.SBP_BlotterCRRFINCON.Where(p => CRRFINCONItem.StartDate >= p.StartDate && CRRFINCONItem.StartDate <= p.EndDate && p.BR == CRRFINCONItem.BR && p.CurID == CRRFINCONItem.CurID).ToList();
                if (GetCount.Count > 0)
                {
                    status = false;
                }
                else
                {

                    List<SBP_BlotterCRRFINCON> GetCount2 = DbContextB.SBP_BlotterCRRFINCON.Where(p => CRRFINCONItem.EndDate >= p.StartDate && CRRFINCONItem.EndDate <= p.EndDate && p.BR == CRRFINCONItem.BR && p.CurID == CRRFINCONItem.CurID).ToList();
                    if (GetCount2.Count > 0)
                    {
                        status = false;
                    }
                    else
                    {
                        DbContextB.SBP_BlotterCRRFINCON.Add(CRRFINCONItem);
                        DbContextB.SaveChanges();
                        DbContextB.SP_AddDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateCRRFINCON(SBP_BlotterCRRFINCON CRRFINCONItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterCRRFINCON> GetCount = DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo == CRRFINCONItem.SNo && p.StartDate >= p.StartDate && p.EndDate <= p.EndDate && p.BR == CRRFINCONItem.BR && p.CurID == CRRFINCONItem.CurID).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterCRRFINCON CRRFINCONItems = DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo == CRRFINCONItem.SNo).FirstOrDefault();
                    if (CRRFINCONItems != null)
                    {
                        CRRFINCONItems.StartDate = CRRFINCONItem.StartDate;
                        CRRFINCONItems.EndDate = CRRFINCONItem.EndDate;
                        CRRFINCONItems.DemandTimeLiablities = CRRFINCONItem.DemandTimeLiablities;
                        CRRFINCONItems.TimeLiablitiesOverOneYear = CRRFINCONItem.TimeLiablitiesOverOneYear;
                        CRRFINCONItems.DemandTimeLiablitiesTotal = CRRFINCONItem.DemandTimeLiablitiesTotal;
                        CRRFINCONItems.PreMatureDeposit = CRRFINCONItem.PreMatureDeposit;
                        CRRFINCONItems.DemandTimeLiablitiesTotalForCRR = CRRFINCONItem.DemandTimeLiablitiesTotalForCRR;
                        CRRFINCONItems.Penalty = CRRFINCONItem.Penalty;
                        CRRFINCONItems.ExtraBenefits = CRRFINCONItem.ExtraBenefits;
                        CRRFINCONItems.CRR1Requirement = CRRFINCONItem.CRR1Requirement;
                        CRRFINCONItems.CRR2Requirement = CRRFINCONItem.CRR2Requirement;
                        CRRFINCONItems.RequirementPenalty = CRRFINCONItem.RequirementPenalty;
                        CRRFINCONItems.RequirementExtBenefit = CRRFINCONItem.RequirementExtBenefit;
                        CRRFINCONItems.CurID = CRRFINCONItem.CurID;
                        CRRFINCONItems.UpdateDate = CRRFINCONItem.UpdateDate;
                        DbContextB.SaveChanges();
                        DbContextB.SP_UpdateDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
                    }
                    status = true;
                }
                else
                {
                    status = false;


                }

            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteCRRFINCON(int id)
        {
            bool status;
            try
            {
                SBP_BlotterCRRFINCON CRRFINCONItem = DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo == id).FirstOrDefault();
                if (CRRFINCONItem != null)
                {
                    DbContextB.SBP_BlotterCRRFINCON.Remove(CRRFINCONItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }




        //*****************************************************
        //TBO Producers
        //*****************************************************
        public static List<SP_GETAllTBOTransactionTitles_Result> GetAllTBOTransactionTitles()
        {
            List<SP_GETAllTBOTransactionTitles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAllTBOTransactionTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetAll_SBPBlotterTBO_Result> GetAllBlotterTBO(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterTBO_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterTBO(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterTBO_DashBoard_Result> GetAllBlotterTBODashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterTBO_DashBoard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterTBO_DashBoard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterTBO GetTBOItem(int TBOId)
        {
            SBP_BlotterTBO results = null;
            try
            {
                results = DbContextB.SBP_BlotterTBO.Where(p => p.SNo == TBOId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertTBO(SBP_BlotterTBO TBOItem)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterTBO.Add(TBOItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateTBO(SBP_BlotterTBO TBOItem)
        {
            bool status;
            try
            {
                SBP_BlotterTBO TboItems = DbContextB.SBP_BlotterTBO.Where(p => p.SNo == TBOItem.SNo).FirstOrDefault();
                if (TboItems != null)
                {
                    TboItems.DataType = TBOItem.DataType;
                    TboItems.TTID = TBOItem.TTID;
                    TboItems.TBO_Date = TBOItem.TBO_Date;
                    TboItems.TBO_InFlow = TBOItem.TBO_InFlow;
                    TboItems.TBO_OutFLow = TBOItem.TBO_OutFLow;
                    TboItems.Note = TBOItem.Note;
                    TboItems.CurID = TBOItem.CurID;
                    TboItems.UpdateDate = TBOItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteTBO(int id)
        {
            bool status;
            try
            {
                SBP_BlotterTBO TBOItem = DbContextB.SBP_BlotterTBO.Where(p => p.SNo == id).FirstOrDefault();
                if (TBOItem != null)
                {
                    DbContextB.SBP_BlotterTBO.Remove(TBOItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //NostroBank Producers
        //*****************************************************

        public static List<NostroBank> GetAllNostroBank()
        {
            List<NostroBank> results = null;
            try
            {
                results = DbContextB.NostroBanks.ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static NostroBank GetNostroBank(int Id)
        {
            NostroBank results = null;
            try
            {
                results = DbContextB.NostroBanks.Where(p => p.ID == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertNostroBank(NostroBank Item)
        {
            bool status;
            try
            {

                DbContextB.NostroBanks.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateNostroBank(NostroBank Item)
        {
            bool status;
            try
            {
                NostroBank Items = DbContextB.NostroBanks.Where(p => p.ID == Item.ID).FirstOrDefault();
                if (Items != null)
                {
                    Items.BankName = Item.BankName;
                    Items.CurId = Item.CurId;
                    Items.NostroLimit = Item.NostroLimit;
                    Items.isActive = Item.isActive;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteNostroBank(int id)
        {
            bool status;
            try
            {
                NostroBank Item = DbContextB.NostroBanks.Where(p => p.ID == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.NostroBanks.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //UserRole Producers
        //*****************************************************

        public static List<SP_GETUserRoles_Result> GetAllUserRole()
        {
            List<SP_GETUserRoles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETUserRoles(null).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SP_GETUserRoles_Result GetUserRole(int Id)
        {
            SP_GETUserRoles_Result results = null;
            try
            {
                results = DbContextB.SP_GETUserRoles(Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertUserRole(string RoleName, bool isActive)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertUserRole(RoleName, isActive);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateUserRole(int URID, string RoleName, bool isActive)
        {
            bool status;
            try
            {
                DbContextB.SP_UPDATEUserRole(URID, RoleName, isActive);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteUserRole(int id)
        {
            bool status;
            try
            {
                DbContextB.SP_DeleteUserRole(id);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //UserPageRelation Producers
        //*****************************************************

        public static List<SP_GETUserRoles_Result> GetActiveUserRoles()
        {
            List<SP_GETUserRoles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETUserRoles(null).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static SP_GetAllWebPages_Result GetWebPageById(int ID)
        {
            SP_GetAllWebPages_Result results = null;
            try
            {
                results = DbContextB.SP_GetAllWebPages(ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetNotListedUserPageRelations_Result> GetActiveWebPages(int URID)
        {
            List<SP_GetNotListedUserPageRelations_Result> results = null;
            try
            {
                results = DbContextB.SP_GetNotListedUserPageRelations(URID).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAllUserPageRelations_Result> GetAllUserPageRelations(int URID)
        {
            List<SP_GetAllUserPageRelations_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllUserPageRelations(URID).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static SP_GetUserPageRelationById_Result GetUserPageRelationById(int UPRID)
        {
            SP_GetUserPageRelationById_Result results = null;
            try
            {
                results = DbContextB.SP_GetUserPageRelationById(UPRID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertUserPageRelation(int URID, int WPID, bool DateChangeAccess, bool EditAccess, bool DeleteAccess)
        {
            bool status;
            try
            {

                DbContextB.SP_INSERTUserPageRelation(URID, WPID, DateChangeAccess, EditAccess, DeleteAccess);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        public static bool UpdateUserPageRelation(int UPRID, int URID, int WPID, bool DateChangeAccess, bool EditAccess, bool DeleteAccess)
        {
            bool status;
            try
            {
                DbContextB.SP_UPDATEUserPageRelation(UPRID, URID, WPID, DateChangeAccess, EditAccess, DeleteAccess);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        public static bool DeleteUserPageRelation(int id)
        {
            bool status;
            try
            {
                DbContextB.SP_DELETEUserPageRelation(id);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        //*****************************************************
        //WebPage Producers
        //*****************************************************

        public static List<SP_GetAllWebPages_Result> GetAllWebPages()
        {
            List<SP_GetAllWebPages_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllWebPages(null).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SP_GetAllWebPages_Result GetWebPage(int Id)
        {
            SP_GetAllWebPages_Result results = null;
            try
            {
                results = DbContextB.SP_GetAllWebPages(Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertWebPages(string PageName, string ControllerName, string DisplayName, string PageDescription, int BlotterType, bool isActive)
        {
            bool status;
            try
            {

                DbContextB.SP_InsertWebPages(PageName, ControllerName, DisplayName, PageDescription, isActive, BlotterType);
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateWebPages(int WPID, string PageName, string ControllerName, string DisplayName, string PageDescription, int BlotterType, bool isActive)
        {
            bool status;
            try
            {

                DbContextB.SP_UpdateWebPages(WPID, PageName, ControllerName, DisplayName, PageDescription, isActive, BlotterType);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteWebPages(int id)
        {
            bool status;
            try
            {
                DbContextB.SP_DeleteWebPages(id);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Branches Producers
        //*****************************************************

        public static List<Branches> GetAllBranches()
        {
            List<Branches> results = null;
            try
            {
                results = DbContextB.Branches.ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static Branches GetBranches(int Id)
        {
            Branches results = null;
            try
            {
                results = DbContextB.Branches.Where(p => p.BID == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertBranches(Branches Item)
        {
            bool status;
            try
            {
                DbContextB.Branches.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateBranches(Branches Item)
        {
            bool status;
            try
            {
                Branches Items = DbContextB.Branches.Where(p => p.BID == Item.BID).FirstOrDefault();
                if (Items != null)
                {
                    Items.BranchCode = Item.BranchCode;
                    Items.BranchName = Item.BranchName;
                    Items.BranchLocation = Item.BranchLocation;
                    Items.BrachDescription = Item.BrachDescription;
                    Items.isActive = Item.isActive;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteBranches(int id)
        {
            bool status;
            try
            {
                Branches Item = DbContextB.Branches.Where(p => p.BID == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.Branches.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }



        //*****************************************************
        //UsersProfile Producers
        //*****************************************************

        public static List<sp_GetAllUsers_Result> GetAllUsers()
        {
            List<sp_GetAllUsers_Result> results = null;
            try
            {
                results = DbContextB.sp_GetAllUsers().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GETUserRoles_Result> GetUserRoles()
        {
            List<SP_GETUserRoles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETUserRoles(null).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
            return DbContextB.SP_GETUserRoles(null).ToList();
        }
        public static sp_GetUserById_Result GetUser(int Id)
        {
            sp_GetUserById_Result results = null;
            try
            {
                results = DbContextB.sp_GetUserById(Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertUser(sp_GetUserById_Result item)
        {
            bool status;
            try
            {
                SBP_LoginInfo Items = DbContextB.SBP_LoginInfo.Where(p => p.Email == item.Email).FirstOrDefault();
                if (Items != null)
                {
                    status = false;
                }
                else
                {
                    DbContextB.SP_InsertLoginInfo(item.UserName, item.Password, item.ContactNo, item.Email, item.Department, item.BranchID, item.isActive, item.isConventional, item.isislamic, item.CreateDate, item.BlotterType, item.URID);
                    DbContextB.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateUser(sp_GetUserById_Result Item)
        {
            bool status;
            try
            {
                SBP_LoginInfo Items = DbContextB.SBP_LoginInfo.Where(p => p.Id != Item.Id && p.Email == Item.Email).FirstOrDefault();
                if (Items != null)
                {
                    status = false;
                }
                else
                {
                    DbContextB.SP_UpdateLoginInfo(Item.Id, Item.UserName, Item.Password, Item.ContactNo, Item.Email, Item.BranchID, Item.Department, Item.isActive, Item.isConventional, Item.isislamic, Item.CreateDate, Item.BlotterType, Item.URID);
                    DbContextB.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteUser(int id)
        {
            bool status;
            try
            {
                SBP_LoginInfo Item = DbContextB.SBP_LoginInfo.Where(p => p.Id == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.SBP_LoginInfo.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //Breakups Producers
        //*****************************************************

        public static SP_GetLatestBreakup_Result GetAllBlotterBreakups(int UserID, int BranchID, int CurID, int BR)
        {
            SP_GetLatestBreakup_Result results = null;
            try
            {
                results = DbContextB.SP_GetLatestBreakup(UserID, BranchID, CurID, BR).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterBreakups GetBlotterBreakups(int Id)
        {
            SBP_BlotterBreakups results = null;
            try
            {
                results = DbContextB.SBP_BlotterBreakups.Where(p => p.SNo == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertBlotterBreakups(SBP_BlotterBreakups Item)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterBreakups.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateBlotterBreakups(SBP_BlotterBreakups Item)
        {
            bool status;
            try
            {
                SBP_BlotterBreakups Items = DbContextB.SBP_BlotterBreakups.Where(p => p.SNo == Item.SNo).FirstOrDefault();
                if (Items != null)
                {
                    Items.BreakupDate = Item.BreakupDate;
                    Items.FoodPayment_inFlow = Item.FoodPayment_inFlow;
                    Items.HOKRemittance_inFlow = Item.HOKRemittance_inFlow;
                    Items.ERF_inflow = Item.ERF_inflow;
                    Items.SBPChequeDeposite_inflow = Item.SBPChequeDeposite_inflow;
                    Items.Miscellaneous_inflow = Item.Miscellaneous_inflow;
                    Items.CashWithdrawbySBPCheques_outFlow = Item.CashWithdrawbySBPCheques_outFlow;
                    Items.ERF_outflow = Item.ERF_outflow;
                    Items.DSC_outFlow = Item.DSC_outFlow;
                    Items.CurID = Item.CurID;
                    Items.RemitanceToHOK_outFlow = Item.RemitanceToHOK_outFlow;
                    Items.SBPCheqGivenToOtherBank_outFlow = Item.SBPCheqGivenToOtherBank_outFlow;
                    Items.Miscellaneous_outflow = Item.Miscellaneous_outflow;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteBlotterBreakups(int id)
        {
            bool status;
            try
            {
                SBP_BlotterBreakups Item = DbContextB.SBP_BlotterBreakups.Where(p => p.SNo == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.SBP_BlotterBreakups.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Clearing Producers
        //*****************************************************
        public static List<SP_GETAllClearingTransactionTitles_Result> GetAllClearingTransactionTitles()
        {
            List<SP_GETAllClearingTransactionTitles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAllClearingTransactionTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result> GetAllRecordCRRReportCalc()
        {
            List<SP_GETAll_MAX_BlotterCRRReportCalcSetup_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAll_MAX_BlotterCRRReportCalcSetup().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterClearing_Result> GetAllBlotterClearing(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterClearing_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterClearing(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterClearing_DashBoard_Result> GetAllBlotterClearingDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterClearing_DashBoard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterClearing_DashBoard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterClearing GetClearingItem(int ClearingId)
        {
            SBP_BlotterClearing results = null;
            try
            {
                results = DbContextB.SBP_BlotterClearing.Where(p => p.SNo == ClearingId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertClearing(SBP_BlotterClearing ClearingItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterClearing.Add(ClearingItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateClearing(SBP_BlotterClearing ClearingItem)
        {
            bool status;
            try
            {
                SBP_BlotterClearing CLRItems = DbContextB.SBP_BlotterClearing.Where(p => p.SNo == ClearingItem.SNo).FirstOrDefault();
                if (CLRItems != null)
                {

                    CLRItems.DataType = ClearingItem.DataType;
                    CLRItems.TTID = ClearingItem.TTID;
                    CLRItems.Clearing_Date = ClearingItem.Clearing_Date;
                    CLRItems.Clearing_InFlow = ClearingItem.Clearing_InFlow;
                    CLRItems.Clearing_OutFLow = ClearingItem.Clearing_OutFLow;
                    CLRItems.Note = ClearingItem.Note;
                    CLRItems.CurID = ClearingItem.CurID;
                    CLRItems.UpdateDate = ClearingItem.UpdateDate;
                    DbContextB.SaveChanges();
                }

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteClearing(int id)
        {
            bool status;
            try
            {
                SBP_BlotterClearing ClearingItem = DbContextB.SBP_BlotterClearing.Where(p => p.SNo == id).FirstOrDefault();
                if (ClearingItem != null)
                {
                    DbContextB.SBP_BlotterClearing.Remove(ClearingItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //FundsTransfer Producers
        //*****************************************************
        public static bool InsertSBP_BlotterCRRReportCalcSetup(SBP_BlotterCRRReportCalcSetup CalcItem)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterCRRReportCalcSetup.Add(CalcItem);
                DbContextB.SaveChanges();
                status = true;
                //}
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        public static bool UpdateSBP_BlotterCRRReportCalcSetup(SBP_BlotterCRRReportCalcSetup CalcItem)
        {
            bool status;
            try
            {

                SBP_BlotterCRRReportCalcSetup CLRItems = DbContextB.SBP_BlotterCRRReportCalcSetup.Where(p => p.ID == CalcItem.ID).FirstOrDefault();
                if (CLRItems != null)
                {
                    CLRItems.CalcVal1 = CalcItem.CalcVal1;
                    CLRItems.CalcVal2 = CalcItem.CalcVal2;
                    CLRItems.StartDate = CalcItem.StartDate;
                    CLRItems.EndDate = CalcItem.EndDate;

                    DbContextB.SaveChanges();
                }

                status = true;
                //}
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        public static List<SBP_BlotterFundsTransfer> GetAllBlotterFundsTransfer(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SBP_BlotterFundsTransfer> results = null;
            try
            {
                results = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.BID == BranchID && p.CurID == CurID && p.BR == BR && (p.FT_Date.ToString() == DateVal || (DateVal == null && p.FT_Date >= DateTime.Today))).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterFundsTransfer GetFundsTransferItem(int FundsTransferId)
        {
            SBP_BlotterFundsTransfer results = null;
            try
            {
                results = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo == FundsTransferId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertFundsTransfer(SBP_BlotterFundsTransfer FundsTransferItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterFundsTransfer.Add(FundsTransferItem);
                DbContextB.SaveChanges();

                if (FundsTransferItem.DataType == "SBP")
                {

                    FundsTransferItem.DataType = "HBLC";
                    if (FundsTransferItem.FT_InFlow != 0)
                    {
                        FundsTransferItem.FT_OutFLow = FundsTransferItem.FT_InFlow * -1;
                        FundsTransferItem.FT_InFlow = 0;
                    }
                    else
                    {
                        FundsTransferItem.FT_InFlow = FundsTransferItem.FT_OutFLow * -1;
                        FundsTransferItem.FT_OutFLow = 0;
                    }
                    DbContextB.SBP_BlotterFundsTransfer.Add(FundsTransferItem);
                    DbContextB.SaveChanges();


                }
                else
                {
                    FundsTransferItem.DataType = "SBP";
                    if (FundsTransferItem.FT_InFlow != 0)
                    {
                        FundsTransferItem.FT_OutFLow = FundsTransferItem.FT_InFlow * -1;
                        FundsTransferItem.FT_InFlow = 0;
                    }
                    else
                    {
                        FundsTransferItem.FT_InFlow = FundsTransferItem.FT_OutFLow * -1;
                        FundsTransferItem.FT_OutFLow = 0;
                    }
                    DbContextB.SBP_BlotterFundsTransfer.Add(FundsTransferItem);
                    DbContextB.SaveChanges();
                }

                status = true;
                //}
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateFundsTransfer(SBP_BlotterFundsTransfer FundsTransferItem)
        {
            bool status;
            try
            {
                SBP_BlotterFundsTransfer CLRItems1 = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo == FundsTransferItem.SNo).FirstOrDefault();
                if (CLRItems1 != null)
                {

                    CLRItems1.DataType = FundsTransferItem.DataType;
                    CLRItems1.FT_Date = FundsTransferItem.FT_Date;
                    CLRItems1.FT_InFlow = FundsTransferItem.FT_InFlow;
                    CLRItems1.FT_OutFLow = FundsTransferItem.FT_OutFLow;
                    CLRItems1.Note = FundsTransferItem.Note;
                    CLRItems1.CurID = FundsTransferItem.CurID;
                    CLRItems1.UpdateDate = FundsTransferItem.UpdateDate;
                    DbContextB.SaveChanges();
                }

                if (FundsTransferItem.DataType == "SBP")
                {

                    FundsTransferItem.DataType = "HBLC";
                    if (FundsTransferItem.FT_InFlow != 0)
                    {
                        FundsTransferItem.FT_OutFLow = FundsTransferItem.FT_InFlow * -1;
                        FundsTransferItem.FT_InFlow = 0;
                    }
                    else
                    {
                        FundsTransferItem.FT_InFlow = FundsTransferItem.FT_OutFLow * -1;
                        FundsTransferItem.FT_OutFLow = 0;
                    }
                }
                else
                {
                    FundsTransferItem.DataType = "SBP";
                    if (FundsTransferItem.FT_InFlow != 0)
                    {
                        FundsTransferItem.FT_OutFLow = FundsTransferItem.FT_InFlow * -1;
                        FundsTransferItem.FT_InFlow = 0;
                    }
                    else
                    {
                        FundsTransferItem.FT_InFlow = FundsTransferItem.FT_OutFLow * -1;
                        FundsTransferItem.FT_OutFLow = 0;
                    }
                }
                long addSno = FundsTransferItem.SNo + 1;
                FundsTransferItem.SNo = addSno;
                SBP_BlotterFundsTransfer CLRItems2 = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo == FundsTransferItem.SNo).FirstOrDefault();
                if (CLRItems2 != null)
                {

                    CLRItems2.DataType = FundsTransferItem.DataType;
                    CLRItems2.FT_Date = FundsTransferItem.FT_Date;
                    CLRItems2.FT_InFlow = FundsTransferItem.FT_InFlow;
                    CLRItems2.FT_OutFLow = FundsTransferItem.FT_OutFLow;
                    CLRItems2.Note = FundsTransferItem.Note;
                    CLRItems2.CurID = FundsTransferItem.CurID;
                    CLRItems2.UpdateDate = FundsTransferItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
                //}
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteFundsTransfer(int id)
        {
            bool status;
            try
            {
                SBP_BlotterFundsTransfer CLRItems2 = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo == id).FirstOrDefault();
                if (CLRItems2 != null)
                {
                    List<SBP_BlotterFundsTransfer> FundsTransferItem;
                    if (CLRItems2.FT_InFlow != 0)
                    {
                        FundsTransferItem = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.FT_Date == CLRItems2.FT_Date && p.FT_InFlow == CLRItems2.FT_InFlow).ToList();
                        if (FundsTransferItem.Count > 0)
                        {
                            foreach (var item in FundsTransferItem)
                            {

                                DbContextB.SBP_BlotterFundsTransfer.Remove(item);
                                DbContextB.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        FundsTransferItem = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.FT_Date == CLRItems2.FT_Date && p.FT_OutFLow == CLRItems2.FT_OutFLow).ToList();
                        if (FundsTransferItem.Count > 0)
                        {
                            foreach (var item in FundsTransferItem)
                            {

                                DbContextB.SBP_BlotterFundsTransfer.Remove(item);
                                DbContextB.SaveChanges();
                            }
                        }
                    }
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //Bai_Muajjal Producers
        //*****************************************************

        public static List<SBP_BlotterBai_Muajjal> GetAllBlotterBai_Muajjal(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SBP_BlotterBai_Muajjal> results = null;
            try
            {
                results = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.BID == BranchID && p.CurID == CurID && p.BR == BR && (p.ValueDate.ToString() == DateVal || (DateVal == null && p.ValueDate >= DateTime.Today))).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterBai_Muajjal GetBai_MuajjalItem(int Bai_MuajjalId)
        {
            SBP_BlotterBai_Muajjal results = null;
            try
            {
                results = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.SNo == Bai_MuajjalId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertBai_Muajjal(SBP_BlotterBai_Muajjal Bai_MuajjalItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterBai_Muajjal.Add(Bai_MuajjalItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateBai_Muajjal(SBP_BlotterBai_Muajjal Bai_MuajjalItem)
        {
            bool status;
            try
            {
                SBP_BlotterBai_Muajjal CLRItems = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.SNo == Bai_MuajjalItem.SNo).FirstOrDefault();
                if (CLRItems != null)
                {

                    CLRItems.ValueDate = Bai_MuajjalItem.ValueDate;
                    CLRItems.MaturityDate = Bai_MuajjalItem.MaturityDate;
                    CLRItems.DataType = Bai_MuajjalItem.DataType;
                    CLRItems.BM_InFlow = Bai_MuajjalItem.BM_InFlow;
                    CLRItems.BM_OutFLow = Bai_MuajjalItem.BM_OutFLow;
                    CLRItems.Note = Bai_MuajjalItem.Note;
                    CLRItems.CurID = Bai_MuajjalItem.CurID;
                    CLRItems.UpdateDate = Bai_MuajjalItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteBai_Muajjal(int id)
        {
            bool status;
            try
            {
                SBP_BlotterBai_Muajjal Bai_MuajjalItem = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.SNo == id).FirstOrDefault();
                if (Bai_MuajjalItem != null)
                {
                    DbContextB.SBP_BlotterBai_Muajjal.Remove(Bai_MuajjalItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Change Password Producers
        //*****************************************************

        public static bool UpdateUserPassword(int UserId, string OldPassword, string NewPassword)
        {
            bool status;
            try
            {

                if (Convert.ToBoolean(DbContextB.SP_UpdateUserPassword(UserId, OldPassword, NewPassword).FirstOrDefault()))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //RTGS Producers
        //*****************************************************
        public static List<SP_GETAllRTGSTransactionTitles_Result> GetAllRTGSTransactionTitles()
        {
            List<SP_GETAllRTGSTransactionTitles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAllRTGSTransactionTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterRTGS_Result> GetAllBlotterRTGS(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterRTGS_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterRTGS(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterRTGS_Dashboard_Result> GetAllBlotterRTGSDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterRTGS_Dashboard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterRTGS_Dashboard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterRTGS GetRTGSItem(int RTGSId)
        {
            SBP_BlotterRTGS results = null;
            try
            {
                results = DbContextB.SBP_BlotterRTGS.Where(p => p.SNo == RTGSId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertRTGS(SBP_BlotterRTGS RTGSItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterRTGS.Add(RTGSItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateRTGS(SBP_BlotterRTGS RTGSItem)
        {
            bool status;
            try
            {
                SBP_BlotterRTGS RTGSItems = DbContextB.SBP_BlotterRTGS.Where(p => p.SNo == RTGSItem.SNo).FirstOrDefault();
                if (RTGSItems != null)
                {
                    RTGSItems.DataType = RTGSItem.DataType;
                    RTGSItems.TTID = RTGSItem.TTID;
                    RTGSItems.RTGS_Date = RTGSItem.RTGS_Date;
                    RTGSItems.RTGS_InFlow = RTGSItem.RTGS_InFlow;
                    RTGSItems.RTGS_OutFLow = RTGSItem.RTGS_OutFLow;
                    RTGSItems.CurID = RTGSItem.CurID;
                    RTGSItems.Note = RTGSItem.Note;
                    RTGSItems.UpdateDate = RTGSItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteRTGS(int id)
        {
            bool status;
            try
            {
                SBP_BlotterRTGS RTGSItem = DbContextB.SBP_BlotterRTGS.Where(p => p.SNo == id).FirstOrDefault();
                if (RTGSItem != null)
                {
                    DbContextB.SBP_BlotterRTGS.Remove(RTGSItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }



        //*****************************************************
        //Opening Balance Producers
        //*****************************************************

        public static List<SP_GetAllOpeningBalance_Result> GetAllBlotterOpenBal(int UserID, int BranchID, int CurID, int BR, string dateVal)
        {
            List<SP_GetAllOpeningBalance_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllOpeningBalance(UserID, BranchID, CurID, BR, dateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterOpeningBalance GetOpenBalItem(int OpnBalId)
        {
            SBP_BlotterOpeningBalance results = null;
            try
            {
                results = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id == OpnBalId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertOpenBal(SBP_BlotterOpeningBalance OpenBalItem)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertOpeningBalance(OpenBalItem.OpenBalActual, OpenBalItem.AdjOpenBal, OpenBalItem.BalDate, OpenBalItem.DataType, OpenBalItem.UserID, OpenBalItem.CreateDate, OpenBalItem.UpdateDate, OpenBalItem.BR, OpenBalItem.BID, OpenBalItem.CurID, OpenBalItem.Flag, OpenBalItem.EstimatedOpenBal);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateOpenBal(SBP_BlotterOpeningBalance OpenBalItem)
        {
            bool status;
            try
            {
                DbContextB.SP_UpdateOpeningBalance(OpenBalItem.Id, OpenBalItem.OpenBalActual, OpenBalItem.AdjOpenBal, OpenBalItem.BalDate, OpenBalItem.DataType, OpenBalItem.UserID, OpenBalItem.CreateDate, OpenBalItem.UpdateDate, OpenBalItem.BR, OpenBalItem.BID, OpenBalItem.CurID, OpenBalItem.Flag, OpenBalItem.EstimatedOpenBal);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteOpenBal(int id)
        {
            bool status;
            try
            {
                SBP_BlotterOpeningBalance OpenBalItem = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id == id).FirstOrDefault();
                if (OpenBalItem != null)
                {
                    DbContextB.SBP_BlotterOpeningBalance.Remove(OpenBalItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }



        //*****************************************************
        //Funding Repo Producers
        //*****************************************************
        public static List<GetIssueTypeTitles_Result> GetAllIssueTypeTitles()
        {
            List<GetIssueTypeTitles_Result> results = null;
            try
            {
                results = DbContextB.GetIssueTypeTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetSBPBlotterFR_Result> GetAllBlotterFundingRepo(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetSBPBlotterFR_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterFR(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetSBPBlotterFRAuto_Result> GetAllblotterFundingRepoAuto(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetSBPBlotterFRAuto_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterFRAuto(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterFundingRepo GetSBP_BlotterFundingRepoById(int FundingRepoId)
        {
            SBP_BlotterFundingRepo results = null;
            try
            {
                results = DbContextB.SBP_BlotterFundingRepo.Where(p => p.SNo == FundingRepoId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertFundingRepo(SBP_BlotterFundingRepo FundingRepoIdItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterFundingRepo.Add(FundingRepoIdItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateFundingRepo(SBP_BlotterFundingRepo FundingRepoIdItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterFundingRepo> GetCount = DbContextB.SBP_BlotterFundingRepo.Where(p => p.SNo == FundingRepoIdItem.SNo).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterFundingRepo prodItem = DbContextB.SBP_BlotterFundingRepo.Where(p => p.SNo == FundingRepoIdItem.SNo).FirstOrDefault();
                    if (prodItem != null)
                    {
                        prodItem.DataType = FundingRepoIdItem.DataType;
                        prodItem.Bank = FundingRepoIdItem.Bank;
                        prodItem.Rate = FundingRepoIdItem.Rate;
                        prodItem.Days = FundingRepoIdItem.Days;
                        prodItem.Issue_Date = FundingRepoIdItem.Issue_Date;
                        prodItem.Broker = FundingRepoIdItem.Broker;
                        prodItem.DealType = FundingRepoIdItem.DealType;
                        prodItem.IssueType = FundingRepoIdItem.IssueType;
                        prodItem.InFlow = FundingRepoIdItem.InFlow;
                        prodItem.OutFLow = FundingRepoIdItem.OutFLow;
                        prodItem.Note = FundingRepoIdItem.Note;
                        prodItem.CurID = FundingRepoIdItem.CurID;
                        prodItem.UpdateDate = FundingRepoIdItem.UpdateDate;
                        DbContextB.SaveChanges();
                    }
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteFundingRepo(int id)
        {
            bool status;
            try
            {
                SBP_BlotterFundingRepo FundingRepoIdItem = DbContextB.SBP_BlotterFundingRepo.Where(p => p.SNo == id).FirstOrDefault();
                if (FundingRepoIdItem != null)
                {
                    FundingRepoIdItem.Status = false;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }




        //*****************************************************
        //Opening Balance Producers
        //*****************************************************

        public static List<SBP_BlotterManualEstBalance> GetAllBlotterEstAdjBal(int UserID, int BranchID, int CurID, int BR)
        {
            List<SBP_BlotterManualEstBalance> results = null;
            try
            {
                results = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.UserID == UserID && p.BID == BranchID && p.CurID == CurID && p.BR == BR && p.isAdjusted == true).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterManualEstBalance GetEstAdjBalById(int EstAdjBalId)
        {
            SBP_BlotterManualEstBalance results = null;
            try
            {
                results = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.SNo == EstAdjBalId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static bool InsertEstAdjBal(SBP_BlotterManualEstBalance EstAdjBalItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterManualEstBalance> GetCount = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.DataType == EstAdjBalItem.DataType && p.AdjDate == EstAdjBalItem.AdjDate && p.BR == EstAdjBalItem.BR).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterManualEstBalance EstAdjBalItems = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.DataType == EstAdjBalItem.DataType && p.AdjDate == EstAdjBalItem.AdjDate && p.BR == EstAdjBalItem.BR).FirstOrDefault();
                    if (EstAdjBalItems != null)
                    {
                        EstAdjBalItems.EstAdjBalance = EstAdjBalItem.EstAdjBalance;
                        EstAdjBalItems.isAdjusted = EstAdjBalItem.isAdjusted;
                        EstAdjBalItems.CurID = EstAdjBalItem.CurID;
                        EstAdjBalItems.UpdateDate = EstAdjBalItem.UpdateDate;
                        DbContextB.SaveChanges();
                    }
                    status = true;
                }
                else
                {
                    DbContextB.SBP_BlotterManualEstBalance.Add(EstAdjBalItem);
                    DbContextB.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateEstAdjBal(SBP_BlotterManualEstBalance EstAdjBalItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterManualEstBalance> GetCount = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.DataType == EstAdjBalItem.DataType && p.AdjDate == EstAdjBalItem.AdjDate && p.BR == EstAdjBalItem.BR).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterManualEstBalance EstAdjBalItems = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.DataType == EstAdjBalItem.DataType && p.AdjDate == EstAdjBalItem.AdjDate && p.BR == EstAdjBalItem.BR).FirstOrDefault();
                    if (EstAdjBalItems != null)
                    {
                        EstAdjBalItems.EstAdjBalance = EstAdjBalItem.EstAdjBalance;
                        EstAdjBalItems.isAdjusted = EstAdjBalItem.isAdjusted;
                        EstAdjBalItems.CurID = EstAdjBalItem.CurID;
                        EstAdjBalItems.UpdateDate = EstAdjBalItem.UpdateDate;
                        DbContextB.SaveChanges();
                    }
                    status = true;
                }
                else
                {
                    SBP_BlotterManualEstBalance EstAdjBalItems = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.SNo == EstAdjBalItem.SNo).FirstOrDefault();
                    if (EstAdjBalItems != null)
                    {
                        EstAdjBalItems.EstAdjBalance = EstAdjBalItem.EstAdjBalance;
                        EstAdjBalItems.isAdjusted = EstAdjBalItem.isAdjusted;
                        EstAdjBalItems.CurID = EstAdjBalItem.CurID;
                        EstAdjBalItems.UpdateDate = EstAdjBalItem.UpdateDate;
                        DbContextB.SaveChanges();
                    }
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteEstAdjBal(int id)
        {
            bool status;
            try
            {
                SBP_BlotterManualEstBalance EstAdjBalItem = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.SNo == id).FirstOrDefault();
                if (EstAdjBalItem != null)
                {
                    DbContextB.SBP_BlotterManualEstBalance.Remove(EstAdjBalItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }



        public static bool ResetEstAdjBal(int id)
        {
            bool status;
            try
            {
                SBP_BlotterManualEstBalance EstAdjBalItems = DbContextB.SBP_BlotterManualEstBalance.Where(p => p.SNo == id).FirstOrDefault();
                if (EstAdjBalItems != null)
                {
                    EstAdjBalItems.isAdjusted = false;
                    EstAdjBalItems.UpdateDate = DateTime.Now;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Trade Producers
        //*****************************************************
        public static List<SP_GETAllTradeTransactionTitles_Result> GetAllTradeTransactionTitles()
        {
            List<SP_GETAllTradeTransactionTitles_Result> results = null;
            try
            {
                results = DbContextB.SP_GETAllTradeTransactionTitles().ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_GetAll_SBPBlotterTrade_Result> GetAllBlotterTrade(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterTrade_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterTrade(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetAll_SBPBlotterTrade_Dashboard_Result> GetAllBlotterTradeDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterTrade_Dashboard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterTrade_Dashboard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result> GetAllBlotterDailyflowsDashboard(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetAll_SBPBlotterDailyFlows_Dashboard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAll_SBPBlotterDailyFlows_Dashboard(UserID, BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }


        public static SBP_BlotterTrade GetTradeItem(int TradeId)
        {
            return DbContextB.SBP_BlotterTrade.Where(p => p.SNo == TradeId).FirstOrDefault();
        }
        public static bool InsertTrade(SBP_BlotterTrade TradeItem)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterTrade.Add(TradeItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateTrade(SBP_BlotterTrade TradeItem)
        {
            bool status;
            try
            {
                SBP_BlotterTrade TRDItems = DbContextB.SBP_BlotterTrade.Where(p => p.SNo == TradeItem.SNo).FirstOrDefault();
                if (TRDItems != null)
                {
                    TRDItems.DataType = TradeItem.DataType;
                    TRDItems.TTID = TradeItem.TTID;
                    TRDItems.Trade_Date = TradeItem.Trade_Date;
                    TRDItems.Trade_InFlow = TradeItem.Trade_InFlow;
                    TRDItems.Trade_OutFLow = TradeItem.Trade_OutFLow;
                    TRDItems.Note = TradeItem.Note;
                    TRDItems.CurID = TradeItem.CurID;
                    TRDItems.UpdateDate = TradeItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteTrade(int id)
        {
            bool status;
            try
            {
                SBP_BlotterTrade TradeItem = DbContextB.SBP_BlotterTrade.Where(p => p.SNo == id).FirstOrDefault();
                if (TradeItem != null)
                {
                    DbContextB.SBP_BlotterTrade.Remove(TradeItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }


        //*****************************************************
        //Blotter DMMO Producers
        //*****************************************************

        public static List<SP_GetSBP_DMMO_Result> GetAllBlotterDMMO(int UserID, int BranchID, int BR, string DateVal)
        {
            List<SP_GetSBP_DMMO_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBP_DMMO(UserID, BranchID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterDMMO GetDMMOItem(int DMMOId)
        {
            SBP_BlotterDMMO results = null;
            try
            {
                results = DbContextB.SBP_BlotterDMMO.Where(p => p.SNo == DMMOId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static bool InsertDMMO(SBP_BlotterDMMO DMMOItem)
        {
            bool status;
            try
            {

                DbContextB.SBP_BlotterDMMO.Add(DMMOItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool UpdateDMMO(SBP_BlotterDMMO DMMOItem)
        {
            bool status;
            try
            {
                SBP_BlotterDMMO DmmoItems = DbContextB.SBP_BlotterDMMO.Where(p => p.SNo == DMMOItem.SNo).FirstOrDefault();
                if (DmmoItems != null)
                {
                    DmmoItems.PakistanBalance = DMMOItem.PakistanBalance;
                    DmmoItems.BalanceDifference = DMMOItem.BalanceDifference;
                    DmmoItems.SBPBalanace = DMMOItem.SBPBalanace;
                    DmmoItems.Date = DMMOItem.Date;
                    DmmoItems.Note = DMMOItem.Note;
                    DmmoItems.UpdateDate = DMMOItem.UpdateDate;
                    DmmoItems.UserID = DMMOItem.UserID;
                    DmmoItems.BR = DMMOItem.BR;
                    DmmoItems.BID = DMMOItem.BID;

                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        public static bool DeleteDMMO(int id)
        {
            bool status;
            try
            {
                SBP_BlotterDMMO DMMOItem = DbContextB.SBP_BlotterDMMO.Where(p => p.SNo == id).FirstOrDefault();
                if (DMMOItem != null)
                {
                    DbContextB.SBP_BlotterDMMO.Remove(DMMOItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Blotter Reserved Producers
        //*****************************************************


        public static List<SP_GetSBP_Reserved_Result> GetAllBlotterReserved(int UserID, int BranchID, int BR)
        {
            List<SP_GetSBP_Reserved_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBP_Reserved(UserID, BranchID, BR).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static SBP_BlotterReserved GetReservedItem(int DMMOId)
        {
            SBP_BlotterReserved results = null;
            try
            {
                results = DbContextB.SBP_BlotterReserved.Where(p => p.SNo == DMMOId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }


        public static bool UpdateReserved(SBP_BlotterReserved ReservedItem)
        {
            bool status;
            try
            {
                SBP_BlotterReserved ReservedItems = DbContextB.SBP_BlotterReserved.Where(p => p.SNo == ReservedItem.SNo).FirstOrDefault();
                if (ReservedItems != null)
                {
                    ReservedItems.BR = ReservedItem.BR;
                    ReservedItems.BID = ReservedItem.BID;
                    ReservedItems.UserID = ReservedItem.UserID;
                    ReservedItems.CurID = ReservedItem.CurID;
                    ReservedItems.BalanceDifference = ReservedItem.BalanceDifference;
                    ReservedItems.BalanceDifference = ReservedItem.BalanceDifference;
                    ReservedItems.BalanceDifference = ReservedItem.BalanceDifference;
                    ReservedItems.SBPBalanace = ReservedItem.SBPBalanace;
                    ReservedItems.UpdateDate = ReservedItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static List<SP_SBPGetLoginInfo_Result> GetBlotterLogin(String userName, String password)
        {
            List<SP_SBPGetLoginInfo_Result> results = null;
            try
            {
                results = DbContextB.SP_SBPGetLoginInfo(userName, password).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
        public static List<SP_SBPGetLoginInfoById_Result> GetBlotterLoginById(int id)
        {
            List<SP_SBPGetLoginInfoById_Result> results = null;
            try
            {
                results = DbContextB.SP_SBPGetLoginInfoById(id).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static void SessionStart(string pSessionID, int pUserID, string pIP, string pLoginGUID, Nullable<DateTime> pLoginTime, Nullable<DateTime> pExpires)
        {
            try
            {
                DbContextB.SP_ADD_SessionStart(pSessionID, pUserID, pIP, pLoginGUID, pLoginTime, pExpires);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }

        }
        public static void ActivityMonitor(string pSessionID, int pUserID, string pIP, string pLoginGUID, string Data, string Activity, string URL)
        {
            try
            {
                DbContextB.SP_ADD_ActivityMonitor(pSessionID, pUserID, pIP, pLoginGUID, Data, Activity, URL);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }

        public static void SessionStop(string pSessionID, int pUserID)
        {
            try
            {
                DbContextB.SP_SBPSessionStop(pSessionID, pUserID);
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
        }



        #region  Add by Shakir




        //*****************************************************
        //Opening Closing Balance Differential Repo Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> GetAllBlotterOpeningClosingBalanceDifferential(int BranchID, int CurID, int BR, string DateVal)
        {
            List<SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> results = null;
            try
            {
                results = DbContextB.SP_GetSBPBlotterOpeningClosingBalanceDIfferential(BranchID, CurID, BR, DateVal).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }


        public static bool UpdaterOpeningClosingBalanceDifferential(int Sno)
        {
            bool status;
            try
            {
                List<SBP_BlotterOpeningClosingBalanceDIfferential> GetCount = DbContextB.SBP_BlotterOpeningClosingBalanceDIfferential.Where(p => p.SNo == Sno).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterOpeningClosingBalanceDIfferential prodItem = DbContextB.SBP_BlotterOpeningClosingBalanceDIfferential.Where(p => p.SNo == Sno).FirstOrDefault();
                    if (prodItem != null)
                    {
                        prodItem.InFlow = 0;
                        prodItem.OutFLow = 0;
                        prodItem.UpdateDate = DateTime.Now;
                        DbContextB.SaveChanges();
                        DbContextB.SP_ReconcileOPICSManualDataFwd(prodItem.BR, prodItem.Date, false);
                    }
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return status;
        }

        //*****************************************************
        //Currencies 
        //*****************************************************
        public static SP_GetAllBlotterCurrencyById_Result GetAllCurrenciesbyid(int userId)
        {
            SP_GetAllBlotterCurrencyById_Result results = null;
            try
            {
                results = DbContextB.SP_GetAllBlotterCurrencyById(userId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        //*****************************************************
        //NostroBank List 
        //*****************************************************

        public static List<SP_GetAllNostroBankList_Result> GetAllNostroBankList(int currId)
        {
            List<SP_GetAllNostroBankList_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllNostroBankList(currId).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        #endregion

        //*****************************************************
        //RSF/TT Procedures
        //*****************************************************
        public static List<SP_GetAllRsfTTTBO_Result> GetAllRSFTT(int BR, DateTime CurDate)
        {
            List<SP_GetAllRsfTTTBO_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllRsfTTTBO(BR, CurDate).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }

        public static List<SP_GetAllRsfTTTBO_Dashboard_Result> GetAllRSFTT_Dasboard(int BR, DateTime CurDate)
        {
            List<SP_GetAllRsfTTTBO_Dashboard_Result> results = null;
            try
            {
                results = DbContextB.SP_GetAllRsfTTTBO_Dashboard(BR, CurDate).ToList();
            }
            catch (Exception ex)
            {
                DAL.WriteLogs(MethodBase.GetCurrentMethod().Name, ex.Message, ex.InnerException.ToString());
            }
            return results;
        }
    }
}
