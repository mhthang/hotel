using HotelManagement.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebApi.Controllers
{
    public class RoomApiController : ApiController
    {
        RoomBLL objBll = new RoomBLL();
        [HttpGet]
        public HttpResponseMessage GetAll(string RoomName, int PageSize, int PageIndex)
        {
            var result = objBll.GetAll(RoomName, PageSize, PageIndex);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage GetByID(int ID)
        {
            var result = objBll.GetByID(ID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage Insert_Update(int ID, string RoomName, int Quantity, string Note, string Userlogin)
        {
            var result = objBll.Insert_Update(ID,RoomName, Quantity, Note, Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage Delete(int ID, string Userlogin)
        {
            var result = objBll.Delete(ID, Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
