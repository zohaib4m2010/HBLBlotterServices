using System;
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
        public static List<SP_SBPBlotter_Result> GetAllBlotterData(String Br, String DataType, String CurrentDate)
        {
            var results = DbContextB.SP_SBPBlotter(Br, DataType,Convert.ToDateTime(CurrentDate)).ToList();
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

        public static List<SP_GetOPICSManualData_Result> GetOPICSManualData(int BR, DateTime Date,string Flag)
        {
            var results = DbContextB.SP_GetOPICSManualData(BR, Date,Flag).ToList();
            return results;
        }



        public static SP_GetOpeningBalance_Result GetOpeningBalance(int BR,DateTime Date)
        {
            //var results = DbContextB.SP_GetOpeningBalance(BR ,DateTime.Now.AddDays(-38)).FirstOrDefault();
            var results = DbContextB.SP_GetOpeningBalance(BR, Date).FirstOrDefault();
            return results;
        }

        public static List<SP_ReconcileOPICSManualData_Result> ReconcileOPICSManualData(int BR, DateTime Date)
        {
            var results = DbContextB.SP_ReconcileOPICSManualData(BR, Date).ToList();
            return results;
        }
        public static BlotterSumEmail GetAllBlotterDataSum(String BrCode)
        {
            //var results = DbContextB.SP_SBPBlotter(BrCode);
            //decimal TotalAmount=0;
            //decimal inAmt1 = 0;
            //decimal inAmt2 = 0;
            //decimal inAmt3 = 0;
            //decimal TInflow = 0;
            //decimal TOutFlow = 0;
            BlotterSumEmail Bmail = new BlotterSumEmail();
            //foreach (var Amt in results)
            //{
            //    inAmt1 = Convert.ToDecimal(Amt.Inflow);
            //    inAmt2 = Convert.ToDecimal(Amt.Outflow);
            //    inAmt3 = Convert.ToDecimal(Amt.OpeningBalance);
            //    TInflow = TInflow + inAmt1;
            //    TOutFlow = TOutFlow + inAmt2;
            //    TotalAmount = TotalAmount + inAmt1 + inAmt2 + inAmt3;                      
            //}
            //Bmail.Balance = TotalAmount/1000000;
            //Bmail.InFlow = TInflow/1000000;
            //Bmail.OutFlow = TOutFlow/1000000;
            return Bmail;
        }
        //*****************************************************
        //Manual Deals Producers
        //*****************************************************
        public static List<SBP_BlotterManualDeals> GetAllDeals(String BrCode)
        {
            return DbContextB.SBP_BlotterManualDeals.Where(p => p.BR == BrCode).ToList();
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
            catch (Exception ex)
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
            catch (Exception ex)
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


        public static List<SP_GetSBPBlotterCRRFINCON_Result> GetAllBlotterCRRFINCON(int UserID, int BranchID, int CurID, int BR)
        {
            var CurrentDate = DateTime.Now;
            return DbContextB.SP_GetSBPBlotterCRRFINCON(UserID, BranchID, CurID, BR).ToList();
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
                List<SBP_BlotterCRRFINCON> GetCount = DbContextB.SBP_BlotterCRRFINCON.Where(p => CRRFINCONItem.StartDate >= p.StartDate && CRRFINCONItem.StartDate <= p.EndDate && p.BR == CRRFINCONItem.BR && p.CurID==CRRFINCONItem.CurID).ToList();
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

        public static List<SP_GetAll_SBPBlotterTBO_Result> GetAllBlotterTBO(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetAll_SBPBlotterTBO(UserID, BranchID, CurID, BR).ToList();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            return DbContextB.UserRoles.Where(p => p.isActive == true).ToList();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            return DbContextB.UserRoles.Where(p => p.isActive == true).ToList();
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
                SBP_LoginInfo Items = DbContextB.SBP_LoginInfo.Where(p => p.Email == item.Email).FirstOrDefault();
                if (Items != null)
                {
                    status = false;
                }
                else {
                    DbContextB.SP_InsertLoginInfo(item.UserName, item.Password, item.ContactNo, item.Email,item.Department, item.BranchID, item.isActive, item.isConventional, item.isislamic, item.CreateDate, item.BlotterType, item.URID);
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

        public static bool UpdateUser(sp_GetUserById_Result Item)
        {
            bool status;
            try
            {
                SBP_LoginInfo Items = DbContextB.SBP_LoginInfo.Where(p => p.Id != Item.Id && p.Email == Item.Email).FirstOrDefault();
                if (Items != null)
                {
                    //Items.UserName = Item.UserName;
                    //Items.Password = Encoding.UTF8.GetBytes(Item.Password);
                    //Items.ContactNo = Item.ContactNo;
                    //Items.Email = Item.Email;
                    //Items.Department = Item.Department;
                    //Items.isActive = Item.isActive;
                    //Items.isConventional = Item.isConventional;
                    //Items.isislamic = Item.isislamic;
                    //Items.BlotterType = Item.BlotterType;
                    //Items.ChangePassword = true;
                    //Items.UpdateDate = Item.UpdateDate;
                    //Items.DefaultPage = Item.DefaultPage;
                    //DbContextB.SaveChanges();

                    status = false;
                }
                else {
                    DbContextB.SP_UpdateLoginInfo(Item.Id,Item.UserName, Item.Password, Item.ContactNo, Item.Email,Item.BranchID, Item.Department, Item.isActive, Item.isConventional, Item.isislamic, Item.CreateDate, Item.BlotterType, Item.URID);
                    DbContextB.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
        public static List<SP_GetAll_SBPBlotterClearing_Result> GetAllBlotterClearing(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetAll_SBPBlotterClearing(UserID, BranchID, CurID, BR).ToList();
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
                //List<SBP_BlotterClearing> GetCount = DbContextB.SBP_BlotterClearing.Where(p => p.TTID == ClearingItem.TTID && p.Clearing_Date == ClearingItem.Clearing_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
                    DbContextB.SBP_BlotterClearing.Add(ClearingItem);
                    DbContextB.SaveChanges();
                    status = true;
                //}
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
                //List<SBP_BlotterClearing> GetCount = DbContextB.SBP_BlotterClearing.Where(p => p.SNo != ClearingItem.SNo && p.TTID == ClearingItem.TTID && p.Clearing_Date == ClearingItem.Clearing_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
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
                //}
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }


        //*****************************************************
        //FundsTransfer Producers
        //*****************************************************


        public static List<SBP_BlotterFundsTransfer> GetAllBlotterFundsTransfer(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SBP_BlotterFundsTransfer.Where(p => p.BID== BranchID && p.CurID== CurID && p.BR== BR).ToList();
        }
        public static SBP_BlotterFundsTransfer GetFundsTransferItem(int FundsTransferId)
        {
            return DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo == FundsTransferId).FirstOrDefault();
        }
        public static bool InsertFundsTransfer(SBP_BlotterFundsTransfer FundsTransferItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterFundsTransfer> GetCount = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.TTID == FundsTransferItem.TTID && p.FundsTransfer_Date == FundsTransferItem.FundsTransfer_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
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
                else {
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
            }
            return status;
        }

        public static bool UpdateFundsTransfer(SBP_BlotterFundsTransfer FundsTransferItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterFundsTransfer> GetCount = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo != FundsTransferItem.SNo && p.TTID == FundsTransferItem.TTID && p.FundsTransfer_Date == FundsTransferItem.FundsTransfer_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
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
                else {
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
                SBP_BlotterFundsTransfer CLRItems2 = DbContextB.SBP_BlotterFundsTransfer.Where(p => p.SNo != FundsTransferItem.SNo).FirstOrDefault();
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
                    else {
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
            }
            return status;
        }


        //*****************************************************
        //Bai_Muajjal Producers
        //*****************************************************

        public static List<SBP_BlotterBai_Muajjal> GetAllBlotterBai_Muajjal(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.UserID==UserID && p.BID == BranchID && p.CurID == CurID && p.BR == BR).ToList();
        }
        public static SBP_BlotterBai_Muajjal GetBai_MuajjalItem(int Bai_MuajjalId)
        {
            return DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.SNo == Bai_MuajjalId).FirstOrDefault();
        }
        public static bool InsertBai_Muajjal(SBP_BlotterBai_Muajjal Bai_MuajjalItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterBai_Muajjal> GetCount = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.TTID == Bai_MuajjalItem.TTID && p.Bai_Muajjal_Date == Bai_MuajjalItem.Bai_Muajjal_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
                DbContextB.SBP_BlotterBai_Muajjal.Add(Bai_MuajjalItem);
                DbContextB.SaveChanges();
                status = true;
                //}
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateBai_Muajjal(SBP_BlotterBai_Muajjal Bai_MuajjalItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterBai_Muajjal> GetCount = DbContextB.SBP_BlotterBai_Muajjal.Where(p => p.SNo != Bai_MuajjalItem.SNo && p.TTID == Bai_MuajjalItem.TTID && p.Bai_Muajjal_Date == Bai_MuajjalItem.Bai_Muajjal_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
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
                //}
            }
            catch (Exception ex)
            {
                status = false;
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
            }
            return status;
        }

        //*****************************************************
        //Change Password Producers
        //*****************************************************

        public static bool UpdateUserPassword(int UserId,string OldPassword,string NewPassword)
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
            }
            return status;
        }

        //*****************************************************
        //RTGS Producers
        //*****************************************************
        public static List<SP_GETAllRTGSTransactionTitles_Result> GetAllRTGSTransactionTitles()
        {
            return DbContextB.SP_GETAllRTGSTransactionTitles().ToList();
        }
        public static List<SP_GetAll_SBPBlotterRTGS_Result> GetAllBlotterRTGS(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetAll_SBPBlotterRTGS(UserID, BranchID, CurID, BR).ToList();
        }
        public static SBP_BlotterRTGS GetRTGSItem(int RTGSId)
        {
            return DbContextB.SBP_BlotterRTGS.Where(p => p.SNo == RTGSId).FirstOrDefault();
        }
        public static bool InsertRTGS(SBP_BlotterRTGS RTGSItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterRTGS> GetCount = DbContextB.SBP_BlotterRTGS.Where(p => p.TTID == RTGSItem.TTID && p.RTGS_Date == RTGSItem.RTGS_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
                    DbContextB.SBP_BlotterRTGS.Add(RTGSItem);
                    DbContextB.SaveChanges();
                    status = true;
                //}
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateRTGS(SBP_BlotterRTGS RTGSItem)
        {
            bool status;
            try
            {
                //List<SBP_BlotterRTGS> GetCount = DbContextB.SBP_BlotterRTGS.Where(p => p.SNo != RTGSItem.SNo && p.TTID == RTGSItem.TTID && p.RTGS_Date == RTGSItem.RTGS_Date).ToList();
                //if (GetCount.Count > 0)
                //{
                //    status = false;
                //}
                //else
                //{
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
                //}
            }
            catch (Exception ex)
            {
                status = false;
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
            }
            return status;
        }



        //*****************************************************
        //Opening Balance Producers
        //*****************************************************

        public static List<SP_GetAllOpeningBalance_Result> GetAllBlotterOpenBal(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetAllOpeningBalance(UserID, BranchID, CurID, BR).ToList();
        }
        public static SBP_BlotterOpeningBalance GetOpenBalItem(int OpnBalId)
        {
            return DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id == OpnBalId).FirstOrDefault();
        }
        public static bool InsertOpenBal(SBP_BlotterOpeningBalance OpenBalItem)
        {
            bool status;
            try
            {
                DbContextB.SP_InsertOpeningBalance(OpenBalItem.OpenBalActual, OpenBalItem.AdjOpenBal, OpenBalItem.BalDate, OpenBalItem.DataType, OpenBalItem.UserID, OpenBalItem.CreateDate, OpenBalItem.UpdateDate, OpenBalItem.BR, OpenBalItem.BID, OpenBalItem.CurID, OpenBalItem.Flag, OpenBalItem.EstimatedOpenBal);
                //List<SBP_BlotterOpeningBalance> GetCount = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.DataType == OpnBalItem.DataType &&  p.BalDate== OpnBalItem.BalDate && p.BR==OpnBalItem.BR).ToList();
                //if (GetCount.Count > 0)
                //{
                //    SBP_BlotterOpeningBalance OpenBalItems = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.DataType == OpnBalItem.DataType && p.BalDate == OpnBalItem.BalDate && p.BR == OpnBalItem.BR).FirstOrDefault();
                //    if (OpenBalItems != null)
                //    {
                //        OpenBalItems.OpenBalActual = OpnBalItem.OpenBalActual;
                //        OpenBalItems.AdjOpenBal = OpnBalItem.AdjOpenBal;
                //        OpenBalItems.CurID = OpnBalItem.CurID;
                //        OpenBalItems.UpdateDate = OpnBalItem.UpdateDate;
                //        DbContextB.SaveChanges();
                //    }
                status = true;
                //}
                //else
                //{
                //    DbContextB.SBP_BlotterOpeningBalance.Add(OpnBalItem);
                //    DbContextB.SaveChanges();
                //    status = true;
                //}
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateOpenBal(SBP_BlotterOpeningBalance OpenBalItem)
        {
            bool status;
            try
            {
                DbContextB.SP_UpdateOpeningBalance(OpenBalItem.Id,OpenBalItem.OpenBalActual,OpenBalItem.AdjOpenBal,OpenBalItem.BalDate,OpenBalItem.DataType,OpenBalItem.UserID,OpenBalItem.CreateDate,OpenBalItem.UpdateDate,OpenBalItem.BR,OpenBalItem.BID,OpenBalItem.CurID,OpenBalItem.Flag,OpenBalItem.EstimatedOpenBal);
                //List<SBP_BlotterOpeningBalance> GetCount = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id != OpenBalItem.Id && p.BalDate == OpenBalItem.BalDate && p.BR == OpenBalItem.BR).ToList();
                //if (GetCount.Count > 0)
                //{
                //    SBP_BlotterOpeningBalance OpenBalItems = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id == OpenBalItem.Id && p.BalDate == OpenBalItem.BalDate && p.BR == OpenBalItem.BR).FirstOrDefault();
                //    if (OpenBalItems != null)
                //    {
                //        OpenBalItems.OpenBalActual = OpenBalItem.OpenBalActual;
                //        OpenBalItems.AdjOpenBal = OpenBalItem.AdjOpenBal;
                //        OpenBalItems.CurID = OpenBalItem.CurID;
                //        OpenBalItems.UpdateDate = OpenBalItem.UpdateDate;
                //        OpenBalItems.UserID = OpenBalItem.UserID;
                //        DbContextB.SaveChanges();
                //    }
                status = true;
                //}
                //else
                //{
                //    SBP_BlotterOpeningBalance OpenBalItems = DbContextB.SBP_BlotterOpeningBalance.Where(p => p.Id == OpenBalItem.Id).FirstOrDefault();
                //    if (OpenBalItems != null)
                //    {
                //        OpenBalItems.OpenBalActual = OpenBalItem.OpenBalActual;
                //        OpenBalItems.AdjOpenBal = OpenBalItem.AdjOpenBal;
                //        OpenBalItems.BalDate = OpenBalItem.BalDate;
                //        OpenBalItems.CurID = OpenBalItem.CurID;
                //        OpenBalItems.UpdateDate = OpenBalItem.UpdateDate;
                //        OpenBalItems.UserID = OpenBalItem.UserID;
                //        DbContextB.SaveChanges();
                //    }
                //    status = true;
                //}
            }
            catch (Exception ex)
            {
                status = false;
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
            }
            return status;
        }



        //*****************************************************
        //Funding Repo Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterFR_Result> GetAllBlotterFundingRepo(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetSBPBlotterFR(UserID, BranchID, CurID, BR).ToList();
        }
        public static SBP_BlotterFundingRepo GetSBP_BlotterFundingRepoById(int FundingRepoId)
        {
            return DbContextB.SBP_BlotterFundingRepo.Where(p => p.SNo == FundingRepoId).FirstOrDefault();
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
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
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
                    DbContextB.SBP_BlotterFundingRepo.Remove(FundingRepoIdItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }




        //*****************************************************
        //Opening Balance Producers
        //*****************************************************

        public static List<SBP_BlotterManualEstBalance> GetAllBlotterEstAdjBal(int UserID, int BranchID, int CurID, int BR)
        {
            return DbContextB.SBP_BlotterManualEstBalance.Where(p => p.UserID == UserID && p.BID==BranchID && p.CurID==CurID && p.BR==BR && p.isAdjusted==true).ToList();
        }
        public static SBP_BlotterManualEstBalance GetEstAdjBalById(int EstAdjBalId)
        {
            return DbContextB.SBP_BlotterManualEstBalance.Where(p => p.SNo == EstAdjBalId).FirstOrDefault();
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
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
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
        public static List<SP_GetAll_SBPBlotterTrade_Result> GetAllBlotterTrade(int UserID, int BranchID, int CurID, int BR)
        {
            // return DbContextB.SBP_BlotterTrade.Where(p => p.UserID == UserID && p.BR == BranchID && p.CurID == CurID).ToList();
            return DbContextB.SP_GetAll_SBPBlotterTrade(UserID, BranchID, CurID, BR).ToList();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            return DbContextB.SBP_BlotterOpening.Where(p => p.BR == BrCode).ToList();
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            return DbContextB.SBP_BlotterDTL.Where(p => p.BR == BrCode).ToList();
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
                status1 = UpdateRunningBal(DTLDealsItem.BR, DTLDealsItem.DTL_Date, DTLDealsItem.DTL_Date.AddDays(DTLDealsItem.NO_OF_Days));
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            var maxID = DbContextB.SBP_BlotterDTLDaysWiseBal.Any() ? DbContextB.SBP_BlotterDTLDaysWiseBal.Max(p => p.Id) : 0;
            return DbContextB.SBP_BlotterDTLDaysWiseBal.Where(p => p.Id == maxID && p.BR == BrCode).FirstOrDefault();
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
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static List<SP_SBPGetLoginInfo_Result> GetBlotterLogin(String userName, String password)
        {
            var results = DbContextB.SP_SBPGetLoginInfo(userName, password).ToList();
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
        public static void ActivityMonitor(string pSessionID, int pUserID, string pIP, string pLoginGUID, string Data, string Activity, string URL)
        {
            DbContextB.SP_ADD_ActivityMonitor(pSessionID, pUserID, pIP, pLoginGUID, Data, Activity, URL);

        }

        public static void SessionStop(string pSessionID, int pUserID)
        {
            DbContextB.SP_SBPSessionStop(pSessionID, pUserID);

        }
        //*****************************************************
        //USER Login Producers
        //*****************************************************
        public static bool UpdateRunningBal(String BrCode, DateTime StartDate, DateTime Enddate)
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



        #region  Add by Shakir
        //*****************************************************
        //CRD Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterCRD_Result> GetAllBlotterCRD(int UserID, int BranchID, int CurID, int BR)
        {
            var CurrentDate = DateTime.Now;
            return DbContextB.SP_GetSBPBlotterCRD(UserID, BranchID, CurID, BR).ToList();
        }
        public static SBP_BlotterCRD GetCRDItem(int CRDId)
        {
            return DbContextB.SBP_BlotterCRD.Where(p => p.SNo == CRDId).FirstOrDefault();
        }

        public static bool InsertCRD(SBP_BlotterCRD CRDItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterCRD.Add(CRDItem);
                DbContextB.SaveChanges();
                //DbContextB.SP_AddDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateCRD(SBP_BlotterCRD CRDItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterCRD> GetCount = DbContextB.SBP_BlotterCRD.Where(p => p.SNo == CRDItem.SNo).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterCRD prodItem = DbContextB.SBP_BlotterCRD.Where(p => p.SNo == CRDItem.SNo).FirstOrDefault();
                    if (prodItem != null)
                    {
                        prodItem.Nostro_Account = CRDItem.Nostro_Account;
                        prodItem.ValueDate = CRDItem.ValueDate;
                        prodItem.CurID = CRDItem.CurID;
                        prodItem.CRD_InFlow = CRDItem.CRD_InFlow;
                        prodItem.CRD_OutFlow = CRDItem.CRD_OutFlow;
                        prodItem.UpdateDate = CRDItem.UpdateDate;
                        DbContextB.SaveChanges();
                        //DbContextB.SP_UpdateDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
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
            }
            return status;
        }

        public static bool DeleteCRD(int id)
        {
            bool status;
            try
            {
                SBP_BlotterCRD CRDItem = DbContextB.SBP_BlotterCRD.Where(p => p.SNo == id).FirstOrDefault();
                if (CRDItem != null)
                {
                    DbContextB.SBP_BlotterCRD.Remove(CRDItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }



        //*****************************************************
        //RECON Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterRECON_Result> GetAllBlotterRECON(int UserID, int BranchID, int CurID, int BR)
        {
            var CurrentDate = DateTime.Now;
            return DbContextB.SP_GetSBPBlotterRECON(UserID, BranchID, CurID, BR).ToList();
        }
        public static SBP_BlotterRECON GetRECONItem(int CRDId)
        {
            return DbContextB.SBP_BlotterRECON.Where(p => p.ID == CRDId).FirstOrDefault();
        }

        public static bool InsertRECON(SBP_BlotterRECON CRDItem)
        {
            bool status;
            try
            {
                DbContextB.SBP_BlotterRECON.Add(CRDItem);
                DbContextB.SaveChanges();
                //DbContextB.SP_AddDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
                status = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                status = false;
            }
            return status;
        }

        public static bool UpdateRECON(SBP_BlotterRECON CRDItem)
        {
            bool status;
            try
            {
                List<SBP_BlotterRECON> GetCount = DbContextB.SBP_BlotterRECON.Where(p => p.ID == CRDItem.ID).ToList();
                if (GetCount.Count > 0)
                {
                    SBP_BlotterRECON prodItem = DbContextB.SBP_BlotterRECON.Where(p => p.ID == CRDItem.ID).FirstOrDefault();
                    if (prodItem != null)
                    {
                        //prodItem.NostroBank = CRDItem.NostroBank;
                        prodItem.NostroBankId = CRDItem.NostroBankId;
                        prodItem.CurID = CRDItem.CurID;
                        prodItem.LastStatementDate = CRDItem.LastStatementDate;
                        prodItem.OurBooks = CRDItem.OurBooks;
                        prodItem.TheirBooks = CRDItem.TheirBooks;
                        prodItem.ConversionRate = CRDItem.ConversionRate;
                        prodItem.EquivalentUSD = CRDItem.EquivalentUSD;
                        prodItem.ConversionRate = CRDItem.ConversionRate;
                        prodItem.LimitAvailable = CRDItem.LimitAvailable;
                        prodItem.UpdateDate = CRDItem.UpdateDate;

                        DbContextB.SaveChanges();
                        //DbContextB.SP_UpdateDaysInBlotterReport(CRRFINCONItem.DemandTimeLiablitiesTotalForCRR, CRRFINCONItem.StartDate, CRRFINCONItem.EndDate, CRRFINCONItem.BR);
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
            }
            return status;
        }

        public static bool DeleteRECON(int id)
        {
            bool status;
            try
            {
                SBP_BlotterRECON CRDItem = DbContextB.SBP_BlotterRECON.Where(p => p.ID == id).FirstOrDefault();
                if (CRDItem != null)
                {
                    DbContextB.SBP_BlotterRECON.Remove(CRDItem);
                    DbContextB.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        //*****************************************************
        //Opening Closing Balance Differential Repo Producers
        //*****************************************************

        public static List<SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> GetAllBlotterOpeningClosingBalanceDifferential(int BranchID, int CurID, int BR)
        {
            return DbContextB.SP_GetSBPBlotterOpeningClosingBalanceDIfferential(BranchID, CurID, BR).ToList();
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
            }
            return status;
        }

        //*****************************************************
        //Currencies 
        //*****************************************************
        public static SP_GetAllBlotterCurrencyById_Result GetAllCurrenciesbyid(int userId)
        {
            var result = DbContextB.SP_GetAllBlotterCurrencyById(userId).FirstOrDefault();
            return result;
        }

        //*****************************************************
        //NostroBank List 
        //*****************************************************

        public static List<SP_GetAllNostroBankList_Result> GetAllNostroBankList(int currId)
        {
            return DbContextB.SP_GetAllNostroBankList(currId).ToList();
        }

        public static List<SP_SBPBlotter_FCY_Result> GetAllBlotterData_FCY(String Br, int CurrId)
        {
            var results = DbContextB.SP_SBPBlotter_FCY(Br, CurrId).ToList();
            return results;
        }
        #endregion
    }
}
