﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
       
        static BlotterEntities DbContextB;
        static DAL()
        {
           
            DbContextB = new BlotterEntities();

        }
        public static List<SP_SBPBlotter_Result> GetAllBlotterData(String Br)
        {
            var results = DbContextB.SP_SBPBlotter(Br).ToList();
            return results;
        }

        public static List<SP_GETLatestBlotterDTLReportDayWise_Result> GetLatestBlotterDTLDayWise(int BR)
        {
            var results = DbContextB.SP_GETLatestBlotterDTLReportDayWise(BR).ToList();
            return results;
        }
        public static SP_GETLatestBlotterDTLReportForToday_Result GetLatestBlotterDTLForToday(int BR)
        {
            var results = DbContextB.SP_GETLatestBlotterDTLReportForToday(BR).FirstOrDefault();
            return results;
        }

        public static List<SP_GetOPICSManualData_Result> GetOPICSManualData(int BR,DateTime Date)
        {
            var results = DbContextB.SP_GetOPICSManualData(BR,Date).ToList();
            return results;
        }

        public static List<SP_ReconcileOPICSManualData_Result> ReconcileOPICSManualData(int BR, DateTime Date)
        {
            var results = DbContextB.SP_ReconcileOPICSManualData(BR, Date).ToList();
            return results;
        }
        public static BlotterSumEmail GetAllBlotterDataSum(String BrCode)
        {
            var results = DbContextB.SP_SBPBlotter(BrCode);
            decimal TotalAmount=0;
            decimal inAmt1 = 0;
            decimal inAmt2 = 0;
            decimal inAmt3 = 0;
            decimal TInflow = 0;
            decimal TOutFlow = 0;
            BlotterSumEmail Bmail = new BlotterSumEmail();
            foreach (var Amt in results)
            {
                inAmt1 = Convert.ToDecimal(Amt.Inflow);
                inAmt2 = Convert.ToDecimal(Amt.Outflow);
                inAmt3 = Convert.ToDecimal(Amt.OpeningBalance);
                TInflow = TInflow + inAmt1;
                TOutFlow = TOutFlow + inAmt2;
                TotalAmount = TotalAmount + inAmt1 + inAmt2 + inAmt3;                      
            }
            Bmail.Balance = TotalAmount/1000000;
            Bmail.InFlow = TInflow/1000000;
            Bmail.OutFlow = TOutFlow/1000000;
            return Bmail;
        }
        //*****************************************************
        //Manual Deals Producers
        //*****************************************************
        public static List<SBP_BlotterManualDeals> GetAllDeals(String BrCode)
        {
            return DbContextB.SBP_BlotterManualDeals.Where(p=>p.BR== BrCode).ToList();
        }
        public static SBP_BlotterManualDeals GetManualDeal(int ManualDealId)
        {
            return DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == ManualDealId).FirstOrDefault();
        }
        public static bool InsertManualDeals(SBP_BlotterManualDeals ManualDealsItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterManualDeals.Add(ManualDealsItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false; 
            }
            return status;
        }
        public static bool UpdateManualDeals(SBP_BlotterManualDeals ManualDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterManualDeals prodItem = DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == ManualDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {
                   
                    prodItem.Description = ManualDealsItem.Description;           
                    prodItem.DealDate = ManualDealsItem.DealDate;   
                    prodItem.InFlow = ManualDealsItem.InFlow;
                    prodItem.OutFlow = ManualDealsItem.OutFlow;             
                    prodItem.CurrentDate = ManualDealsItem.CurrentDate;
                    prodItem.DealStatus = ManualDealsItem.DealStatus;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        

        public static bool DeleteManualDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterManualDeals prodItem = DbContextB.SBP_BlotterManualDeals.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterManualDeals.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //Setup Producers
        //*****************************************************
        public static List<SBP_BlotterSetup> GetAllSetUpItems()
        {
            return DbContextB.SBP_BlotterSetup.ToList();
        }




        //*****************************************************
        //CRRFINCON Producers
        //*****************************************************


        public static List<SP_GetSBPBlotterCRRFINCON_Result> GetAllBlotterCRRFINCON(int UserID, int BranchID, int CurID,int BR)
        {
            var CurrentDate = DateTime.Now;
            return DbContextB.SP_GetSBPBlotterCRRFINCON(UserID,BranchID,CurID,BR).ToList();
        }
        public static SBP_BlotterCRRFINCON GetCRRFINCONItem(int CRRFINCONId)
        {
            return DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo == CRRFINCONId).FirstOrDefault();
        }

        public static bool InsertCRRFINCON(SBP_BlotterCRRFINCON CRRFINCONItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterCRRFINCON> GetCount = DbContextB.SBP_BlotterCRRFINCON.Where(p => CRRFINCONItem.StartDate >= p.StartDate && CRRFINCONItem.StartDate <= p.EndDate).ToList();
                if (GetCount.Count > 0)
                {
                    status = false;
                }
                else
                {

                    List<SBP_BlotterCRRFINCON> GetCount2 = DbContextB.SBP_BlotterCRRFINCON.Where(p => CRRFINCONItem.EndDate >= p.StartDate && CRRFINCONItem.EndDate <= p.EndDate).ToList();
                    if (GetCount2.Count > 0)
                    {
                        status = false;
                    }
                    else
                    {
                        DbContextB.SBP_BlotterCRRFINCON.Add(CRRFINCONItem);
                        DbContextB.SaveChanges();
                        DbContextB.SP_AddDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate,CRRFINCONItem.BR);
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateCRRFINCON(SBP_BlotterCRRFINCON CRRFINCONItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterCRRFINCON> GetCount = DbContextB.SBP_BlotterCRRFINCON.Where(p => p.SNo==CRRFINCONItem.SNo && p.StartDate >= p.StartDate && p.EndDate <= p.EndDate).ToList();
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
                            CRRFINCONItems.UpdateDate = CRRFINCONItem.UpdateDate;
                            DbContextB.SaveChanges();
                            DbContextB.SP_UpdateDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate,CRRFINCONItem.BR);
                        }
                        status = true;
                }
                else
                {
                    status = false;

                    
                }

            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }




        //*****************************************************
        //TBO Producers
        //*****************************************************
        public static List<SP_GETAllTBOTransactionTitles_Result> GetAllTBOTransactionTitles()
        {
            return DbContextB.SP_GETAllTBOTransactionTitles().ToList();
        }

        public static List<SP_GetAll_SBPBlotterTBO_Result> GetAllBlotterTBO(int UserID, int BranchID, int CurID,int BR)
        {
            return DbContextB.SP_GetAll_SBPBlotterTBO(UserID,BranchID,CurID,BR).ToList();
        }
        public static SBP_BlotterTBO GetTBOItem(int TBOId)
        {
            return DbContextB.SBP_BlotterTBO.Where(p => p.SNo == TBOId).FirstOrDefault();
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
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
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
                    TboItems.TBO_InFlow = TBOItem.TBO_InFlow;
                    TboItems.TBO_OutFLow = TBOItem.TBO_OutFLow;
                    TboItems.Note = TBOItem.Note;
                    TboItems.UpdateDate = TBOItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //NostroBank Producers
        //*****************************************************

        public static List<NostroBank> GetAllNostroBank()
        {
            return DbContextB.NostroBanks.ToList();
        }
        public static NostroBank GetNostroBank(int Id)
        {
            return DbContextB.NostroBanks.Where(p => p.ID == Id).FirstOrDefault();
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
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
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
                    Items.NostroLimit = Item.NostroLimit;
                    Items.isActive = Item.isActive;
                    Items.UpdateDate =Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        //*****************************************************
        //UserRole Producers
        //*****************************************************

        public static List<UserRole> GetAllUserRole()
        {
            return DbContextB.UserRoles.ToList();
        }
        public static UserRole GetUserRole(int Id)
        {
            return DbContextB.UserRoles.Where(p => p.URID == Id).FirstOrDefault();
        }

        public static bool InsertUserRole(UserRole Item)
        {
            bool status;
            try
            {

                DbContextB.UserRoles.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateUserRole(UserRole Item)
        {
            bool status;
            try
            {
                UserRole Items = DbContextB.UserRoles.Where(p => p.URID == Item.URID).FirstOrDefault();
                if (Items != null)
                {
                    Items.RoleName = Item.RoleName;
                    Items.isActive = Item.isActive;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteUserRole(int id)
        {
            bool status;
            try
            {
                UserRole Item = DbContextB.UserRoles.Where(p => p.URID == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.UserRoles.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //UserPageRelation Producers
        //*****************************************************

        public static List<UserRole> GetActiveUserRoles()
        {
            return DbContextB.UserRoles.Where(p=>p.isActive==true).ToList();
        }

        public static WebPages GetWebPageById(int ID)
        {
            return DbContextB.WebPages.Where(p => p.WPID == ID).FirstOrDefault();
        }
        public static List<SP_GetNotListedUserPageRelations_Result> GetActiveWebPages(int URID)
        {
            return DbContextB.SP_GetNotListedUserPageRelations(URID).ToList();
        }
        public static List<SP_GetAllUserPageRelations_Result> GetAllUserPageRelations(int URID)
        {
            return DbContextB.SP_GetAllUserPageRelations(URID).ToList();
        }

        public static SP_GetUserPageRelationById_Result GetUserPageRelationById(int UPRID)
        {
            return DbContextB.SP_GetUserPageRelationById(UPRID).FirstOrDefault();
        }
        public static bool InsertUserPageRelation(UserPageRelation Item)
        {
            bool status;
            try
            {

                DbContextB.UserPageRelations.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }
        public static bool UpdateUserPageRelation(UserPageRelation Item)
        {
            bool status;
            try
            {
                UserPageRelation Items = DbContextB.UserPageRelations.Where(p => p.UPRID == Item.UPRID).FirstOrDefault();
                if (Items != null)
                {
                    Items.DateChangeAccess = Item.DateChangeAccess;
                    Items.EditAccess = Item.EditAccess;
                    Items.DeleteAccess = Item.DeleteAccess;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteUserPageRelation(int id)
        {
            bool status;
            try
            {
                UserPageRelation Item = DbContextB.UserPageRelations.Where(p => p.UPRID == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.UserPageRelations.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //WebPage Producers
        //*****************************************************

        public static List<WebPages> GetAllWebPages()
        {
            return DbContextB.WebPages.ToList();
        }
        public static WebPages GetWebPage(int Id)
        {
            return DbContextB.WebPages.Where(p => p.WPID == Id).FirstOrDefault();
        }

        public static bool InsertWebPages(WebPages Item)
        {
            bool status;
            try
            {

                DbContextB.WebPages.Add(Item);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateWebPages(WebPages Item)
        {
            bool status;
            try
            {
                WebPages Items = DbContextB.WebPages.Where(p => p.WPID == Item.WPID).FirstOrDefault();
                if (Items != null)
                {
                    Items.PageName = Item.PageName;
                    Items.PageDescription = Item.PageDescription;
                    Items.ControllerName = Item.ControllerName;
                    Items.DisplayName = Item.DisplayName;
                    Items.isActive = Item.isActive;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public static bool DeleteWebPages(int id)
        {
            bool status;
            try
            {
                WebPages Item = DbContextB.WebPages.Where(p => p.WPID == id).FirstOrDefault();
                if (Item != null)
                {
                    DbContextB.WebPages.Remove(Item);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //Branches Producers
        //*****************************************************

        public static List<Branches> GetAllBranches()
        {
            return DbContextB.Branches.ToList();
        }
        public static Branches GetBranches(int Id)
        {
            return DbContextB.Branches.Where(p => p.BID == Id).FirstOrDefault();
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
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }



        //*****************************************************
        //UsersProfile Producers
        //*****************************************************

        public static List<sp_GetAllUsers_Result> GetAllUsers()
        {
            return DbContextB.sp_GetAllUsers().ToList();
        }
        public static List<UserRole> GetUserRoles()
        {
            return DbContextB.UserRoles.Where(p=>p.isActive==true).ToList();
        }
        public static sp_GetUserById_Result GetUser(int Id)
        {
            return DbContextB.sp_GetUserById(Id).FirstOrDefault();
        }
        public static bool InsertUser(sp_GetUserById_Result item)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertLoginInfo(item.UserName, item.Password, item.ContactNo, item.Email, item.BranchId, item.isActive, item.isConventional, item.isislamic, item.CreateDate,item.BlotterType, item.URID);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateUser(sp_GetUserById_Result Item)
        {
            bool status;
            try
            {
                SBP_LoginInfo Items = DbContextB.SBP_LoginInfo.Where(p => p.Id == Item.Id).FirstOrDefault();
                if (Items != null)
                {
                    Items.UserName = Item.UserName;
                    Items.Password = Item.Password;
                    Items.ContactNo = Item.ContactNo;
                    Items.Email = Item.Email;
                    Items.isActive = Item.isActive;
                    Items.isConventional = Item.isConventional;
                    Items.isislamic = Item.isislamic;
                    Items.BlotterType = Item.BlotterType;
                    Items.UpdateDate = Item.UpdateDate;
                    Items.DefaultPage = Item.DefaultPage;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        //*****************************************************
        //Breakups Producers
        //*****************************************************

        public static SP_GetLatestBreakup_Result GetAllBlotterBreakups(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetLatestBreakup(UserID, BranchID, CurID, BR).FirstOrDefault();
        }
        public static SBP_BlotterBreakups GetBlotterBreakups(int Id)
        {
            return DbContextB.SBP_BlotterBreakups.Where(p => p.SNo == Id).FirstOrDefault();
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
            }
            return status;
        }

        public static bool UpdateBreakupsOpngBal(SBP_BlotterBreakups Item)
        {
            bool status;
            try
            {
                SBP_BlotterBreakups Items = DbContextB.SBP_BlotterBreakups.Where(p => p.SNo == Item.SNo).FirstOrDefault();
                if (Items != null)
                {
                    Items.OpeningBalActual = Item.OpeningBalActual;
                    Items.EstimatedCLossingBal = Item.OpeningBalActual + (Items.HOKRemittance_inFlow + Items.FoodPayment_inFlow + Items.Miscellaneous_inflow + Items.ERF_inflow+Items.SBPChequeDeposite_inflow)+(Items.CashWithdrawbySBPCheques_outFlow+Items.DSC_outFlow+Items.ERF_outflow+Items.Miscellaneous_outflow+Items.SBPCheqGivenToOtherBank_outFlow+Items.RemitanceToHOK_outFlow);
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
                    Items.OpeningBalActual = Item.OpeningBalActual;
                    Items.FoodPayment_inFlow = Item.FoodPayment_inFlow;
                    Items.HOKRemittance_inFlow = Item.HOKRemittance_inFlow;
                    Items.ERF_inflow = Item.ERF_inflow;
                    Items.SBPChequeDeposite_inflow = Item.SBPChequeDeposite_inflow;
                    Items.Miscellaneous_inflow = Item.Miscellaneous_inflow;
                    Items.CashWithdrawbySBPCheques_outFlow = Item.CashWithdrawbySBPCheques_outFlow;
                    Items.ERF_outflow = Item.ERF_outflow;
                    Items.DSC_outFlow = Item.DSC_outFlow;
                    Items.RemitanceToHOK_outFlow = Item.RemitanceToHOK_outFlow;
                    Items.SBPCheqGivenToOtherBank_outFlow = Item.SBPCheqGivenToOtherBank_outFlow;
                    Items.Miscellaneous_outflow = Item.Miscellaneous_outflow;
                    Items.EstimatedCLossingBal = Item.EstimatedCLossingBal;
                    Items.UpdateDate = Item.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //Clearing Producers
        //*****************************************************
        public static List<SP_GETAllClearingTransactionTitles_Result> GetAllClearingTransactionTitles()
        {
            return DbContextB.SP_GETAllClearingTransactionTitles().ToList();
        }
        public static List<SP_GetAll_SBPBlotterClearing_Result> GetAllBlotterClearing(int UserID,int BranchID, int CurID,int BR)
        {
            return DbContextB.SP_GetAll_SBPBlotterClearing(UserID,BranchID,CurID,BR).ToList();
        }
        public static SBP_BlotterClearing GetClearingItem(int ClearingId)
        {
            return DbContextB.SBP_BlotterClearing.Where(p => p.SNo == ClearingId).FirstOrDefault();
        }
        public static bool InsertClearing(SBP_BlotterClearing ClearingItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterClearing> GetCount = DbContextB.SBP_BlotterClearing.Where(p => p.TTID == ClearingItem.TTID && p.Clearing_Date == ClearingItem.Clearing_Date).ToList();
                if (GetCount.Count > 0)
                {
                    status = false;
                }
                else
                {
                    DbContextB.SBP_BlotterClearing.Add(ClearingItem);
                    DbContextB.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateClearing(SBP_BlotterClearing ClearingItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterClearing> GetCount = DbContextB.SBP_BlotterClearing.Where(p => p.SNo!=ClearingItem.SNo && p.TTID == ClearingItem.TTID && p.Clearing_Date == ClearingItem.Clearing_Date).ToList();
                if (GetCount.Count > 0)
                {
                    status = false;
                }
                else
                {
                    SBP_BlotterClearing TboItems = DbContextB.SBP_BlotterClearing.Where(p => p.SNo == ClearingItem.SNo).FirstOrDefault();
                    if (TboItems != null)
                    {
                        TboItems.Clearing_InFlow = ClearingItem.Clearing_InFlow;
                        TboItems.Clearing_OutFLow = ClearingItem.Clearing_OutFLow;
                        TboItems.Note = ClearingItem.Note;
                        TboItems.UpdateDate = ClearingItem.UpdateDate;
                        DbContextB.SaveChanges();
                    }
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //Trade Producers
        //*****************************************************
        public static List<SP_GETAllTradeTransactionTitles_Result> GetAllTradeTransactionTitles()
        {
            return DbContextB.SP_GETAllTradeTransactionTitles().ToList();
        }
        public static List<SP_GetAll_SBPBlotterTrade_Result> GetAllBlotterTrade(int UserID, int BranchID, int CurID,int BR)
        {
            // return DbContextB.SBP_BlotterTrade.Where(p => p.UserID == UserID && p.BR == BranchID && p.CurID == CurID).ToList();
            return DbContextB.SP_GetAll_SBPBlotterTrade(UserID,BranchID,CurID,BR).ToList();
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
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateTrade(SBP_BlotterTrade TradeItem)
        {
            bool status;
            try
            {
                SBP_BlotterTrade TboItems = DbContextB.SBP_BlotterTrade.Where(p => p.SNo == TradeItem.SNo).FirstOrDefault();
                if (TboItems != null)
                {
                    TboItems.Trade_InFlow = TradeItem.Trade_InFlow;
                    TboItems.Trade_OutFLow = TradeItem.Trade_OutFLow;
                    TboItems.Note = TradeItem.Note;
                    TboItems.UpdateDate = TradeItem.UpdateDate;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
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
            catch (Exception)
            {
                status = false;
            }
            return status;
        }







        public static SBP_BlotterSetup GetSetUpItem(int SetupId)
        {
            return DbContextB.SBP_BlotterSetup.Where(p => p.SNo == SetupId).FirstOrDefault();
        }
        public static bool InsertSetUp(SBP_BlotterSetup SetupItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterSetup.Add(SetupItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateSetUp(SBP_BlotterSetup SetupItem)
        {
            bool status;
            try
            {
                SBP_BlotterSetup setupItem = DbContextB.SBP_BlotterSetup.Where(p => p.SNo == SetupItem.SNo).FirstOrDefault();
                if (setupItem != null)
                {
                    setupItem.Description = SetupItem.Description;
                    setupItem.status = SetupItem.status;                  
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteSetUp(int id)
        {
            bool status;
            try
            {
                SBP_BlotterSetup setupItem = DbContextB.SBP_BlotterSetup.Where(p => p.SNo == id).FirstOrDefault();
                if (setupItem != null)
                {
                    DbContextB.SBP_BlotterSetup.Remove(setupItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //Opening Deals Producers
        //*****************************************************
        public static List<SBP_BlotterOpening> GetAllOpeningAmount(String BrCode)
        {
            return DbContextB.SBP_BlotterOpening.Where(p=>p.BR== BrCode).ToList();
        }
        public static SBP_BlotterOpening GetOpeningDeal(int Id)
        {
            return DbContextB.SBP_BlotterOpening.Where(p => p.SNo == Id).FirstOrDefault();
        }
        public static bool InsertOpeningDeals(SBP_BlotterOpening OpeningDealsItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterOpening.Add(OpeningDealsItem);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }
        public static bool UpdateOpeningDeals(SBP_BlotterOpening OpeningDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterOpening prodItem = DbContextB.SBP_BlotterOpening.Where(p => p.SNo == OpeningDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {

                    prodItem.CurrentDate = OpeningDealsItem.CurrentDate;
                    prodItem.TodayAmount = OpeningDealsItem.TodayAmount;                   
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteOpeningDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterOpening prodItem = DbContextB.SBP_BlotterOpening.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterOpening.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //System Current Date  Producers
        //*****************************************************
        public static List<SP_SBPOpicsSystemDate_Result> GetSystemDT(String BrCode)
        {
            var results = DbContextB.SP_SBPOpicsSystemDate(BrCode).ToList();
            return results;
        }
        //*****************************************************
        //Manual DTL Producers
        //*****************************************************
        public static List<SBP_BlotterDTL> GetAllDTLDeals(String BrCode)
        {
            return DbContextB.SBP_BlotterDTL.Where(p=> p.BR==BrCode).ToList();
        }

        public static SBP_BlotterDTL GetDTLDeal(int DTLDealId)
        {
            return DbContextB.SBP_BlotterDTL.Where(p => p.SNo == DTLDealId).FirstOrDefault();
        }
        public static bool InsertDTLDeals(SBP_BlotterDTL DTLDealsItem)
        {
            bool status;
            bool status1;
            try
            {
                
                DbContextB.SBP_BlotterDTL.Add(DTLDealsItem);
                DbContextB.SaveChanges();
                status1=UpdateRunningBal(DTLDealsItem.BR, DTLDealsItem.DTL_Date, DTLDealsItem.DTL_Date.AddDays(DTLDealsItem.NO_OF_Days) );
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }
        public static bool UpdateDTLDeals(SBP_BlotterDTL DTLDealsItem)
        {
            bool status;
            try
            {
                SBP_BlotterDTL prodItem = DbContextB.SBP_BlotterDTL.Where(p => p.SNo == DTLDealsItem.SNo).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.DTL_Date = DTLDealsItem.DTL_Date;
                    prodItem.DTL_Code = DTLDealsItem.DTL_Code;
                    prodItem.NO_OF_Days = DTLDealsItem.NO_OF_Days;
                    prodItem.DTL_Amount = DTLDealsItem.DTL_Amount;
                    prodItem.T_User_Id = DTLDealsItem.T_User_Id;
                    prodItem.T_Date = DTLDealsItem.T_Date;
                    prodItem.Flag = DTLDealsItem.Flag;

                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteDTLDeals(int id)
        {
            bool status;
            try
            {
                SBP_BlotterDTL prodItem = DbContextB.SBP_BlotterDTL.Where(p => p.SNo == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContextB.SBP_BlotterDTL.Remove(prodItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //DTL DeskBoard Producers
        //*****************************************************
        public static SBP_BlotterDTLDaysWiseBal GetDTLDeskBoard(String BrCode)
        {
            //return DbContextB.SBP_BlotterDTLDaysWiseBal.ToList();
            var maxID = DbContextB.SBP_BlotterDTLDaysWiseBal.Any() ? DbContextB.SBP_BlotterDTLDaysWiseBal.Max(p => p.Id ) : 0; 
            return DbContextB.SBP_BlotterDTLDaysWiseBal.Where(p => p.Id == maxID && p.BR== BrCode).FirstOrDefault();
        }
        public static bool UpdateWiseBal(SBP_BlotterDTLDaysWiseBal WiseBalItem)
        {
            bool status;
            try
            {
                SBP_BlotterDTLDaysWiseBal prodItem = DbContextB.SBP_BlotterDTLDaysWiseBal.Where(p => p.Id == WiseBalItem.Id).FirstOrDefault();
                if (prodItem != null)
                {
                    //prodItem.Id = WiseBalItem.Id;
                    prodItem.DTL_Days = WiseBalItem.DTL_Days;
                    prodItem.DTL_Date = WiseBalItem.DTL_Date;
                    prodItem.NextDate = WiseBalItem.NextDate;
                    prodItem.DTL_Amount = WiseBalItem.DTL_Amount;
                    prodItem.MinAmount_3P = WiseBalItem.MinAmount_3P;
                    prodItem.MaxAmount_5P = WiseBalItem.MaxAmount_5P;

                    prodItem.Friday_01 = WiseBalItem.Friday_01;
                    prodItem.Date_01 = WiseBalItem.Date_01;
                    prodItem.CashFlow_01 = WiseBalItem.CashFlow_01;
                    prodItem.CashOutFlow_01 = WiseBalItem.CashOutFlow_01;

                    prodItem.Saturday_02 = WiseBalItem.Saturday_02;
                    prodItem.Date_02 = WiseBalItem.Date_02;
                    prodItem.CashFlow_02 = WiseBalItem.CashFlow_02;
                    prodItem.CashOutFlow_02 = WiseBalItem.CashOutFlow_02;

                    prodItem.Sunday_03 = WiseBalItem.Sunday_03;
                    prodItem.Date_03 = WiseBalItem.Date_03;
                    prodItem.CashFlow_03 = WiseBalItem.CashFlow_03;
                    prodItem.CashOutFlow_03 = WiseBalItem.CashOutFlow_03;

                    prodItem.Monday_04 = WiseBalItem.Monday_04;
                    prodItem.Date_04 = WiseBalItem.Date_04;
                    prodItem.CashFlow_04 = WiseBalItem.CashFlow_04;
                    prodItem.CashOutFlow_04 = WiseBalItem.CashOutFlow_04;

                    prodItem.Tuesday_05 = WiseBalItem.Tuesday_05;
                    prodItem.Date_05 = WiseBalItem.Date_05;
                    prodItem.CashFlow_05 = WiseBalItem.CashFlow_05;
                    prodItem.CashOutFlow_05 = WiseBalItem.CashOutFlow_05;

                    prodItem.Wednesday_06 = WiseBalItem.Wednesday_06;
                    prodItem.Date_06 = WiseBalItem.Date_06;
                    prodItem.CashFlow_06 = WiseBalItem.CashFlow_06;
                    prodItem.CashOutFlow_06 = WiseBalItem.CashOutFlow_06;

                    prodItem.Thursday_07 = WiseBalItem.Thursday_07;
                    prodItem.Date_07 = WiseBalItem.Date_07;
                    prodItem.CashFlow_07 = WiseBalItem.CashFlow_07;
                    prodItem.CashOutFlow_07 = WiseBalItem.CashOutFlow_07;

                    prodItem.Friday_08 = WiseBalItem.Friday_08;
                    prodItem.Date_08 = WiseBalItem.Date_08;
                    prodItem.CashFlow_08 = WiseBalItem.CashFlow_08;
                    prodItem.CashOutFlow_08 = WiseBalItem.CashOutFlow_08;

                    prodItem.Saturday_09 = WiseBalItem.Saturday_09;
                    prodItem.Date_09 = WiseBalItem.Date_09;
                    prodItem.CashFlow_09 = WiseBalItem.CashFlow_09;
                    prodItem.CashOutFlow_09 = WiseBalItem.CashOutFlow_09;

                    prodItem.Sunday_10 = WiseBalItem.Sunday_10;
                    prodItem.Date_10 = WiseBalItem.Date_10;
                    prodItem.CashFlow_10 = WiseBalItem.CashFlow_10;
                    prodItem.CashOutFlow_10 = WiseBalItem.CashOutFlow_10;

                    prodItem.Monday_11 = WiseBalItem.Monday_11;
                    prodItem.Date_11 = WiseBalItem.Date_11;
                    prodItem.CashFlow_11 = WiseBalItem.CashFlow_11;
                    prodItem.CashOutFlow_11 = WiseBalItem.CashOutFlow_11;

                    prodItem.Tuesday_12 = WiseBalItem.Tuesday_12;
                    prodItem.Date_12 = WiseBalItem.Date_12;
                    prodItem.CashFlow_12 = WiseBalItem.CashFlow_12;
                    prodItem.CashOutFlow_12 = WiseBalItem.CashOutFlow_12;

                    prodItem.Wednesday_13 = WiseBalItem.Wednesday_13;
                    prodItem.Date_13 = WiseBalItem.Date_13;
                    prodItem.CashFlow_13 = WiseBalItem.CashFlow_13;
                    prodItem.CashOutFlow_13 = WiseBalItem.CashOutFlow_13;

                    prodItem.Thursday_14 = WiseBalItem.Thursday_14;
                    prodItem.Date_14 = WiseBalItem.Date_14;
                    prodItem.CashFlow_14 = WiseBalItem.CashFlow_14;
                    prodItem.CashOutFlow_14 = WiseBalItem.CashOutFlow_14;
                    prodItem.BR = WiseBalItem.BR;
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static List<SP_SBPGetLoginInfo_Result> GetBlotterLogin(String userName,String password)
        {
            var results = DbContextB.SP_SBPGetLoginInfo(userName,password).ToList();
            return results;
        }
        public static List<SP_SBPGetLoginInfoById_Result> GetBlotterLoginById(int id)
        {
            var results = DbContextB.SP_SBPGetLoginInfoById(id).ToList();
            return results;
        }

        public static void SessionStart(string pSessionID, int pUserID, string pIP, string pLoginGUID, Nullable<DateTime> pLoginTime, Nullable<DateTime> pExpires)
        {
            DbContextB.SP_ADD_SessionStart(pSessionID, pUserID, pIP, pLoginGUID, pLoginTime, pExpires);
            
        }
        public static void ActivityMonitor(string pSessionID, int pUserID, string pIP, string pLoginGUID,string Data, string Activity,string URL)
        {
            DbContextB.SP_ADD_ActivityMonitor(pSessionID, pUserID, pIP, pLoginGUID,Data,Activity,URL);

        }

        public static void SessionStop(string pSessionID, int pUserID)
        {
            DbContextB.SP_SBPSessionStop(pSessionID, pUserID);

        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static bool UpdateRunningBal(String BrCode,DateTime StartDate,DateTime Enddate)
        {
            bool status;
            try
            {
                int i = DbContextB.SP_SBPBlotterRunningBal(BrCode, StartDate, Enddate);
                DbContextB.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;

          

         
        }
    }
}
 