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
            DateTime dtFromDate = DateTime.Now;
            if (!string.IsNullOrEmpty(objOrder.CheckinDate))
            {
                var arr = objOrder.CheckinDate.Substring(0,objOrder.CheckinDate.IndexOf(" ")).Split('/');
                var arrHour = objOrder.CheckinDate.Substring(objOrder.CheckinDate.IndexOf(" ") + 1).Split(':');
                dtFromDate = new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[0]), Convert.ToInt32(arrHour[0]), Convert.ToInt32(arrHour[1]),0);
            }
            DateTime dtToDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(objOrder.CheckOutDate))
            {
                var arr = objOrder.CheckOutDate.Substring(0, objOrder.CheckOutDate.LastIndexOf(" ")).Split('/');
                var arrHour = objOrder.CheckOutDate.Substring(objOrder.CheckOutDate.LastIndexOf(" ") + 1).Split(':');
                dtToDate = new DateTime(Convert.ToInt32(arr[2]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[0]), Convert.ToInt32(arrHour[0]), Convert.ToInt32(arrHour[1]), 0);
            }
            var result = objBLL.Insert_Update(objOrder.OrderID, objOrder.RoomID, objOrder.CustomerID, objOrder.CustomerName, objOrder.Phone, objOrder.Address, objOrder.IDNo, objOrder.Email, dtFromDate, dtToDate, objOrder.QuantityPeople, objOrder.Note, objOrder.Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage OrderDetail_Delete(int OrderID, string Userlogin)
        {
            var result = objBLL.OrderDetail_Delete(OrderID,Userlogin);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage OrderDetailInsert([FromBody]OrderDetail objDetail)
        {
            var result = objBLL.Insert_OrderDetail(objDetail.OrderID,objDetail.ProductID,objDetail.Quantity,objDetail.Price,objDetail.Note,"Chó Quốc");
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        public HttpResponseMessage Order_Room_UpdateStatus(int intRoomID, int intOrderID, int intStatus)
        {
            var result = objBLL.Order_Room_UpdateStatus(intRoomID, intOrderID, intStatus);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
