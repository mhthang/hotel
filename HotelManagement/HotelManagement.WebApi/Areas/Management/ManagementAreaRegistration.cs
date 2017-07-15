using System.Web.Mvc;

namespace HotelManagement.WebApi.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrderList",
                "danh-sach-phong",
                new { controller = "Order", action = "RoomList" }
            );
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}