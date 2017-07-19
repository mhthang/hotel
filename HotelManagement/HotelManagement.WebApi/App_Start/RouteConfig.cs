using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelManagement.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         //   routes.MapRoute(
         //     name: "trang-chu",
         //     url: "trang-chu",
         //     defaults: new { controller = "Home", action = "Index" }
         // );
         //   routes.MapRoute(
         //     name: "danh-sach-phong",
         //     url: "danh-sach-phong",
         //     defaults: new { controller = "Room", action = "RoomList" }
         // );
         //   routes.MapRoute(
         //    name: "phieu-dat-phong",
         //     url: "{controller}/{action}/{id}",
         //    defaults: new { controller = "Room", action = "RoomDetail", id = UrlParameter.Optional }
         //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
