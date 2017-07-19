using HotelManagement.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebApi.Controllers
{
    public class System_UserApiController : ApiController
    {
        System_UserBLL objBLL = new System_UserBLL();

        public HttpResponseMessage GetAll(string FullName, int intPositionID, string strIDNo, string strPhone)
        {
            var result = objBLL.GetAll(FullName, intPositionID, strIDNo, strPhone);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage GetByUsername(string Username)
        {
            var result = objBLL.GetByUsername(Username);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage Insert_Update(string strUsername, string Fullname, int Position, string Phone, string Address, string Image, string Note, string Userlogin)
        {
            var result = objBLL.Insert_Update(strUsername, Fullname, Position, Phone, Address, Image, Note, Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage Delete(string Username, string Userlogin)
        {
            var result = objBLL.Delete(Username, Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage Login(string Username,string Password)
        {
            var result = objBLL.Login(Username, Password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }

}
