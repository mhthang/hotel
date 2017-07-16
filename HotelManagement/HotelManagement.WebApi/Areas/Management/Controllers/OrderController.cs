using HotelManagement.Business.BLL;
using HotelManagement.Business.BO.Order;
using Insite.Bussiness.Repository;
using Insite.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.WebApi.Areas.Management.Controllers
{
    public class OrderController : Controller
    {
        RoomBLL objRoomBll = new RoomBLL();
        OrderBLL objOrderBll = new OrderBLL();
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RoomList()
        {
            return View();
        }
        public ActionResult RoomDetail()
        {
            return View();
        }
        public ActionResult GetRoomOrderByStatus(int Status, int PageSize, int PageIndex)
        {
            ResponseModel objResponse;
            DataTable result = objRoomBll.GetRoomOrderByStatus(Status, PageSize, PageIndex);
            string strData = DataHelper.ConvertDataTableToString(result, true);
            objResponse = new ResponseModel(null, strData, null);
            return Json(objResponse);
        }
        //public ActionResult GetRoomDetail(int OrderID)
        //{
        //    OrderBLL objOrderBll = new OrderBLL();  
        //    OrderBO objOrder = new OrderBO();
        //    objOrder = objOrderBll.GetByID(OrderID); 
        //    return Json(objOrder);
        //}
    }
}