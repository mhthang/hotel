using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.WebApi.Controllers
{
    public class RoomController : Controller
    {
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
    }
}