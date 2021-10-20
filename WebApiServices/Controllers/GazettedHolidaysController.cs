using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Web.Http.Results;
using WebApiServices.Models;
using WebApiServices.Classes;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class GazettedHolidaysController : ApiController
    {
        [HttpGet]
        public SBP_WebApiResponse GetblotterGH(int id)
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterGazettedHolidays<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.GazettedHoliday> mapObj = new EntitiyMapperBlotterGazettedHolidays<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.GazettedHoliday>();
                DataAccessLayer.SP_GetSBPBlotterGH_Result dalblotterGH = DAL.GetGHItem(id);
                Models.GazettedHoliday products = new Models.GazettedHoliday();
                products = mapObj.Translate(dalblotterGH);
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(products, Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (products != null)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Success",
                        Data = jsonResponse
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Failed",
                        Data = ""
                    };
                }

                return responseData;
            }
            catch (Exception ex)
            {

                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }
        }
        [HttpGet]
        public SBP_WebApiResponse GetAllblotterGH()
        {
            var responseData = (dynamic)null;
            try
            {
                EntitiyMapperBlotterGazettedHolidays<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.SP_GetSBPBlotterGH_Result> mapObj = new EntitiyMapperBlotterGazettedHolidays<DataAccessLayer.SP_GetSBPBlotterGH_Result, Models.SP_GetSBPBlotterGH_Result>();
                List<DataAccessLayer.SP_GetSBPBlotterGH_Result> blotterGHList = DAL.GetAllBlotterGH();
                List<Models.SP_GetSBPBlotterGH_Result> blotterGH = new List<Models.SP_GetSBPBlotterGH_Result>();
                foreach (var item in blotterGHList)
                {
                    blotterGH.Add(mapObj.Translate(item));
                }

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                var jsonResponse = JsonConvert.SerializeObject(blotterGH.ToList(), Formatting.Indented);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                if (blotterGH.Count > 0)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Success",
                        Data = jsonResponse
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Failed",
                        Data = ""
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {

                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }

        }
        [HttpPost]
        public SBP_WebApiResponse InsertGH(Models.GazettedHoliday blotterGH)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {

                    status = DAL.InsertGH( blotterGH.HolidayTitle, blotterGH.GHDescription, blotterGH.GHDate, blotterGH.UserID);
                    HttpResponseMessage response = null;
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    if (status == true)
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = true,
                            Message = "Record is successfully inserted!",
                            Data = ""
                        };
                    }
                    else
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = false,
                            Message = "Record could not be inserted",
                            Data = ""
                        };
                    }

                }
                return responseData;
            }
            catch (Exception ex)
            {

                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }

        }


        [HttpPut]
        public SBP_WebApiResponse UpdateGH(Models.GazettedHoliday blotterGH)
        {
            bool status = false;
            var responseData = (dynamic)null;
            try
            {
                if (ModelState.IsValid)
                {
                    status = DAL.UpdateGH(blotterGH.GHID, blotterGH.HolidayTitle, blotterGH.GHDescription, blotterGH.GHDate, blotterGH.UserID);

                    HttpResponseMessage response = null;
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    if (status == true)
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = true,
                            Message = "Record is successfully updated!",
                            Data = ""
                        };
                    }
                    else
                    {
                        responseData = new SBP_WebApiResponse
                        {
                            Status = false,
                            Message = "Record could not be updated",
                            Data = ""
                        };
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Failed",
                    Data = ex.Message
                };
                return responseData;
            }
        }


        [HttpDelete]
        public SBP_WebApiResponse DeleteGH(int id)
        {
            bool status = false;
            var responseData = (dynamic)null;

            try
            {
                status = DAL.DeleteGH(id);

                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK);
                if (status == true)
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = true,
                        Message = "Record is successfully deleted!",
                        Data = ""
                    };
                }
                else
                {
                    responseData = new SBP_WebApiResponse
                    {
                        Status = false,
                        Message = "Record could not be deleted",
                        Data = ""
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData = new SBP_WebApiResponse
                {
                    Status = false,
                    Message = "Record could not be deleted",
                    Data = ex.ToString()
                };
                return responseData;
            }

        }
    }
}
