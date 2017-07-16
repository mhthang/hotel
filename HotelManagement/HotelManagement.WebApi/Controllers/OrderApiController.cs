using HotelManagement.Business.BLL;
using HotelManagement.Business.BO.Order;
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
        public HttpResponseMessage GetByID(int OrderID)
        {
            var result = objBLL.GetByID(OrderID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpPost]
        public HttpResponseMessage Insert_Update([FromBody]OrderBO objOrder)
        {
            var result = objBLL.Insert_Update(objOrder.OrderID, objOrder.RoomID, objOrder.CustomerID, objOrder.CustomerName, objOrder.Phone, objOrder.Address, objOrder.IDNo, objOrder.Email, Convert.ToDateTime(objOrder.CheckinDate), Convert.ToDateTime(objOrder.CheckOutDate), objOrder.QuantityPeople, objOrder.Note, objOrder.Userlogin,objOrder.OrderDetail);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
