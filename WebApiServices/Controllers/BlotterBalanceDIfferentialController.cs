using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiServices.Repository;

namespace WebApiServices.Controllers
{
    public class BlotterBalanceDIfferentialController : ApiController
    {

        [HttpGet]
        public JsonResult<List<Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>> GetAllblotteropeningclosingbaldiff(int BranchID, int CurID, int BR, string DateVal)
        {
            EntitiyMapperBlotterBalDiff<DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result, Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> mapObj = new EntitiyMapperBlotterBalDiff<DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result, Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>();

            List<DataAccessLayer.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> blotterbaldiffList = DAL.GetAllBlotterOpeningClosingBalanceDifferential(BranchID, CurID, BR, DateVal);
            List<Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result> blotterBalDiff = new List<Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>();
            foreach (var item in blotterbaldiffList)
            {
                blotterBalDiff.Add(mapObj.Translate(item));
            }
            return Json<List<Models.SP_GetSBPBlotterOpeningClosingBalanceDIfferential_Result>>(blotterBalDiff);
        }

        [HttpPost]
        public bool UpdateOpeningClosingBalanceDifferential(IEnumerable<int> BalDiffIds)
        {
            bool status = false;
            foreach (var item in BalDiffIds)
            {
                status = DAL.UpdaterOpeningClosingBalanceDifferential(item);
            }
            return status;
        }
    }
}
