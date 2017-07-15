using HotelManagement.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebApi.Controllers
{
    public class OrderApiController : ApiController
    {
        private OrderBLL objBLL = new OrderBLL();
        [HttpGet]
        public HttpResponseMessage GetRoomOrderByStatus(int OrderID)
        {
            var result = objBLL.GetByID(OrderID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
