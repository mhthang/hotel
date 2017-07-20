using HotelManagement.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.WebApi.Controllers
{
    public class ProductApiController : ApiController
    {
        private ProductBLL objBLL = new ProductBLL();
        public HttpResponseMessage GetAll(string Keyword, int PageSize, int PageIndex)
        {
            var result = objBLL.GetAll(Keyword, PageSize, PageIndex);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        public HttpResponseMessage GetGroupByOrderID(int OrderID)
        {
            var result = objBLL.GetGroupByOrderID(OrderID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        public HttpResponseMessage Insert_Update(int ProductID, string ProductName, int Price, int Unit, string Note, string Userlogin)
        {
            var result = objBLL.Insert_Update(ProductID, ProductName, Price, Unit, Note,"Cho quoc");
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
