using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterFundingRepoController : ApiController
    {
        #region Latest Code
        //[HttpGet]
        //public SBP_WebApiResponse GetAllblotterFundingRepo(int UserID, int BranchID, int CurID, int BR)
        //{
        //    EntitiyMapperBlotterFR<DataAccessLayer.SP_GetSBPBlotterFR_Result, Models.SP_GetSBPBlotterFR_Result> mapObj = new EntitiyMapperBlotterFR<DataAccessLayer.SP_GetSBPBlotterFR_Result, Models.SP_GetSBPBlotterFR_Result>();

        //    List<DataAccessLayer.SP_GetSBPBlotterFR_Result> blotterFRList = DAL.GetAllBlotterFundingRepo(UserID, BranchID, CurID, BR);
        //    List<Models.SP_GetSBPBlotterFR_Result> blotterFR = new List<Models.SP_GetSBPBlotterFR_Result>();
        //    foreach (var item in blotterFRList)
        //    {
        //        blotterFR.Add(mapObj.Translate(item));
        //    }
        //    var responseData = (dynamic)null;
        //    HttpResponseMessage response = null;
        //    response = Request.CreateResponse(HttpStatusCode.OK);
        //    var jsonResponse = JsonConvert.SerializeObject(blotterFR.ToList(), Formatting.Indented);
        //    response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
        //    if (blotterFR.Count > 0)
        //    {
        //        responseData = new SBP_WebApiResponse
        //        {
        //            Status = true,
        //            Message = "Success",
        //            Data = jsonResponse
        //        };
        //    }
        //    else
        //    {
        //        responseData = new SBP_WebApiResponse
        //        {
        //            Status = false,
        //            Message = "Failed",
        //            Data = ""
        //        };
        //    }
        //    return responseData;
        //}

        //[HttpPost]
        //public SBP_WebApiResponse InsertFundingRepo(List<Models.SBP_BlotterFundingRepo> blotterFR)
        //{
        //    bool status = false;
        //    var responseData = (dynamic)null;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo> mapObj = new EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo>();
        //            DataAccessLayer.SBP_BlotterFundingRepo FRObj = new DataAccessLayer.SBP_BlotterFundingRepo();
        //            for (int i = 0; i < blotterFR.Count; i++)
        //            {
        //                FRObj = mapObj.Translate(blotterFR[i]);
        //                status = DAL.InsertFundingRepo(FRObj);
        //            }

        //            HttpResponseMessage response = null;
        //            response = Request.CreateResponse(HttpStatusCode.OK);
        //            if (status == true)
        //            {
        //                responseData = new SBP_WebApiResponse
        //                {
        //                    Status = true,
        //                    Message = "Record is successfully inserted!",
        //                    Data = ""
        //                };
        //            }
        //            else
        //            {
        //                responseData = new SBP_WebApiResponse
        //                {
        //                    Status = false,
        //                    Message = "Record could not be inserted",
        //                    Data = ""
        //                };
        //            }

        //        }
        //        return responseData;
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData = new SBP_WebApiResponse
        //        {
        //            Status = false,
        //            Message = "Record could not be inserted",
        //            Data = ex.Message
        //        };
        //        return responseData;
        //    }

        //}


        //[HttpPost]
        //public SBP_WebApiResponse DeleteFundingRepo(IEnumerable<int> Ids)
        //{
        //    bool status = false;
        //    var responseData = (dynamic)null;

        //    try
        //    {
        //        foreach (var item in Ids)
        //        {
        //            status = DAL.DeleteFundingRepo(item);
        //        }

        //        HttpResponseMessage response = null;
        //        response = Request.CreateResponse(HttpStatusCode.OK);
        //        if (status == true)
        //        {
        //            responseData = new SBP_WebApiResponse
        //            {
        //                Status = true,
        //                Message = "Record is successfully deleted!",
        //                Data = ""
        //            };
        //        }
        //        else
        //        {
        //            responseData = new SBP_WebApiResponse
        //            {
        //                Status = false,
        //                Message = "Record could not be deleted",
        //                Data = ""
        //            };
        //        }
        //        return responseData;
        //    }
        //    catch (Exception ex)
        //    {
        //        responseData = new SBP_WebApiResponse
        //        {
        //            Status = false,
        //            Message = "Record could not be deleted",
        //            Data = ex.Message
        //        };
        //        return responseData;
        //    }

        //}


        #endregion

        public JsonResult<List<Models.IssueTypeTitles>> GetIssueTypeTitles()
        {
            EntityMapperIssueTypeTitles<DataAccessLayer.GetIssueTypeTitles_Result, Models.IssueTypeTitles> mapObj = new EntityMapperIssueTypeTitles<DataAccessLayer.GetIssueTypeTitles_Result, Models.IssueTypeTitles>();
            List<DataAccessLayer.GetIssueTypeTitles_Result> IssueTypes = DAL.GetAllIssueTypeTitles();
            List<Models.IssueTypeTitles> titles = new List<Models.IssueTypeTitles>();
            foreach(var items in IssueTypes)
            {
                titles.Add(mapObj.Translate(items));
            }
            return Json<List<Models.IssueTypeTitles>>(titles);
        }


        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterFR_Result>> GetAllblotterFundingRepo(int UserID, int BranchID, int CurID, int BR, string DateVal)
        {
            EntitiyMapperBlotterFR<DataAccessLayer.SP_GetSBPBlotterFR_Result, Models.SP_GetSBPBlotterFR_Result> mapObj = new EntitiyMapperBlotterFR<DataAccessLayer.SP_GetSBPBlotterFR_Result, Models.SP_GetSBPBlotterFR_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterFR_Result> blotterFRList = DAL.GetAllBlotterFundingRepo(UserID, BranchID, CurID, BR, DateVal);
            List<Models.SP_GetSBPBlotterFR_Result> blotterFR = new List<Models.SP_GetSBPBlotterFR_Result>();
            foreach (var item in blotterFRList)
            {
                blotterFR.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterFR_Result>>(blotterFR);
        }


        [HttpPost]
        public bool InsertFundingRepo(List<Models.SBP_BlotterFundingRepo> blotterFR)
        {
            bool status = false;

            if (ModelState.IsValid)
            {

                EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo> mapObj = new EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo>();
                DataAccessLayer.SBP_BlotterFundingRepo FRObj = new DataAccessLayer.SBP_BlotterFundingRepo();
                for (int i = 0; i < blotterFR.Count; i++)
                {
                    //blotterFR[i].DataType=()
                    FRObj = mapObj.Translate(blotterFR[i]);
                    status = DAL.InsertFundingRepo(FRObj);
                }
            }
            return status;
        }

        [HttpPost]
        public bool AddFundingRepo(Models.SBP_BlotterFundingRepo blotterFR)
        {
            bool status = false;
            EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo> mapObj = new EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo>();
            DataAccessLayer.SBP_BlotterFundingRepo FRObj = new DataAccessLayer.SBP_BlotterFundingRepo();
            FRObj = mapObj.Translate(blotterFR);
            status = DAL.InsertFundingRepo(FRObj);
            return status;
        }

        [HttpPut]
        public bool UpdateFundingRepo(Models.SBP_BlotterFundingRepo fundingRepo)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo> mapObj = new EntitiyMapperBlotterFR<Models.SBP_BlotterFundingRepo, DataAccessLayer.SBP_BlotterFundingRepo>();
                DataAccessLayer.SBP_BlotterFundingRepo FundingRepo = new DataAccessLayer.SBP_BlotterFundingRepo();
                FundingRepo = mapObj.Translate(fundingRepo);
                status = DAL.UpdateFundingRepo(FundingRepo);
            }
            return status;


        }
        [HttpPost]
        public bool DeleteFundingRepo(IEnumerable<int> Ids)
        {
            bool status = false;
            foreach (var item in Ids)
            {
                status = DAL.DeleteFundingRepo(item);
            }
            return status;
        }
    }
}
