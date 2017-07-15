﻿using HotelManagement.Business.BLL;
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
    }
}
