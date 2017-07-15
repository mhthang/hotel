using HotelManagement.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebApi.Controllers
{
    public class CustomerApiController : ApiController
    {
        private CustomerBLL objBLL = new CustomerBLL();
        public HttpResponseMessage GetAll(string Keyword,string Phone, int PageSize, int PageIndex)
        {
            var result = objBLL.GetAll(Keyword, Phone, PageSize, PageIndex);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
