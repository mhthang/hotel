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
        [HttpGet]
        public HttpResponseMessage GetAll(string FullName, int intPositionID, string strIDNo, string strPhone)
        {
            var result = objBLL.GetAll(FullName, intPositionID, strIDNo, strPhone);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetByUsername(string Username)
        {
            var result = objBLL.GetByUsername(Username);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage Insert_Update(string strUsername,string Password, string Fullname, int Position,string IDNo, string Phone, string Address, string Image, string Note)
        {
            var result = objBLL.Insert_Update(strUsername, Password, Fullname, Position, IDNo, Phone, Address, Image, Note, "DMQ");
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

        public HttpResponseMessage ChangePassword(string Username, string Password)
        {
            int success = 0;
            if (objBLL.ChangePassword(Username, Password))
                success = 1;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, success);
            return response;

        }
    }

}
