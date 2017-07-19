using HotelManagement.Business.BO.Order;
using HotelManagement.Business.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.BLL
{
    
    public class OrderBLL
    {
        private OrderDAO objDAO = new OrderDAO();
        public OrderBO GetByID(int intOrderID)
        {
            OrderBO objOrder = new OrderBO();
            DataTable dt = objDAO.GetByID(intOrderID);
            if (dt.Rows.Count > 0)
            {
                objOrder.Address = dt.Rows[0]["Address"].ToString();
                objOrder.CheckinDate = !string.IsNullOrEmpty(dt.Rows[0]["CheckInDate"].ToString()) ? Convert.ToDateTime(dt.Rows[0]["CheckInDate"].ToString()).ToString("dd/MM/yyyy hh:mm") : string.Empty;
                objOrder.CheckOutDate = !string.IsNullOrEmpty(dt.Rows[0]["CheckOutDate"].ToString()) ? Convert.ToDateTime(dt.Rows[0]["CheckOutDate"].ToString()).ToString("dd/MM/yyyy hh:mm") : string.Empty;
                objOrder.CustomerID = !string.IsNullOrEmpty(dt.Rows[0]["CustomerID"].ToString()) ? Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString()) : -1;
                objOrder.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                objOrder.Email = dt.Rows[0]["Email"].ToString();
                objOrder.IDNo = dt.Rows[0]["IDNo"].ToString();
                objOrder.Note = dt.Rows[0]["Note"].ToString();
                objOrder.OrderID = !string.IsNullOrEmpty(dt.Rows[0]["OrderID"].ToString()) ? Convert.ToInt32(dt.Rows[0]["OrderID"].ToString()) : -1;
                objOrder.Phone = dt.Rows[0]["Phone"].ToString();
                objOrder.QuantityPeople = !string.IsNullOrEmpty(dt.Rows[0]["QuantityPeople"].ToString()) ? Convert.ToInt32(dt.Rows[0]["QuantityPeople"].ToString()) : 0;
                objOrder.RoomID = !string.IsNullOrEmpty(dt.Rows[0]["RoomID"].ToString()) ? Convert.ToInt32(dt.Rows[0]["RoomID"].ToString()) : -1;
                objOrder.RoomName = dt.Rows[0]["RoomName"].ToString();
                objOrder.PriceRoom = !string.IsNullOrEmpty(dt.Rows[0]["PriceRoom"].ToString()) ? Convert.ToInt32(dt.Rows[0]["PriceRoom"].ToString()) : 0;
                objOrder.TotalRoom = !string.IsNullOrEmpty(dt.Rows[0]["TotalRoom"].ToString()) ? Convert.ToInt32(dt.Rows[0]["TotalRoom"].ToString()) : 0;
                objOrder.Userlogin = "Chó Quốc";// nhớ sửa lại =)))
                objOrder.OrderDetail = new List<OrderDetail>();
                foreach (DataRow item in dt.Rows)
                {
                    OrderDetail objDetail = new OrderDetail();
                    objDetail.OrderID  = !string.IsNullOrEmpty(item["OrderID"].ToString()) ? Convert.ToInt32(item["OrderID"].ToString()) : -1;
                    objDetail.Note = item["Note"].ToString();
                    objDetail.ProductName = item["ProductName"].ToString();
                    objDetail.Price = !string.IsNullOrEmpty(item["Price"].ToString()) ? Convert.ToInt32(item["Price"].ToString()) : 0;
                    objDetail.ProductID = !string.IsNullOrEmpty(item["ProductID"].ToString()) ? Convert.ToInt32(item["ProductID"].ToString()) : -1;
                    objDetail.Quantity = !string.IsNullOrEmpty(item["Quantity"].ToString()) ? Convert.ToInt32(item["Quantity"].ToString()) : 0;
                    objDetail.CreatedDate  = !string.IsNullOrEmpty(item["CreatedDate"].ToString()) ? Convert.ToDateTime(item["CreatedDate"].ToString()).ToString("dd/MM/yyyy hh:mm") : string.Empty;
                    objOrder.OrderDetail.Add(objDetail);
                }
            }
            
            return objOrder;
        }
        public int Insert_Update(int intOrderID, int intRoomID, int intCustomerID, string strCustomerName, string strPhone, string strAddress, string strIDNo, string strEmail, DateTime CheckinDate, DateTime CheckOutDate, int intQuantityPeople, string Note, string Userlogin)
        {
            if (CheckinDate == null | CheckinDate == DateTime.MinValue)
            {
                CheckinDate = DateTime.Now;
            }
            
            int OrderID = objDAO.Insert_Update(intOrderID, intRoomID, intCustomerID, strCustomerName, strPhone, strAddress, strIDNo, strEmail, CheckinDate, CheckOutDate, intQuantityPeople, Note, Userlogin);
            return 1;
        }

        public int Insert_OrderDetail(int intOrderID, int intProductID,int intQuantity, double dPrice,string Note, string Userlogin)
        {
            int value = objDAO.InsertDetail(intOrderID, intProductID,intQuantity,dPrice,Note, Userlogin);
            return 1;
        }

        public int OrderDetail_Delete(int intOrderID, string strUserlogin)
        {
            return objDAO.OrderDetail_Delete(intOrderID,strUserlogin);
        }
    }
}
