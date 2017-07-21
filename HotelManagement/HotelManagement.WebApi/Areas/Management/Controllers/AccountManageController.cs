using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.WebApi.Areas.Management.Controllers
{
    public class AccountManageController : Controller
    {
        // GET: Management/AccountManage
        public ActionResult UserList()
        {
            return View();
        }
    }
}