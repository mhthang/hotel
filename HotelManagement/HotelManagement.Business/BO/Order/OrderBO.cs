using System;
using System.Collections.Generic;

namespace HotelManagement.Business.BO.Order
{
    public class OrderBO
    {
        public int OrderID { get; set; }
        public int RoomID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IDNo { get; set; }
        public string Email { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int QuantityPeople { get; set; }
        public string Note { get; set; }
        public string Userlogin { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}