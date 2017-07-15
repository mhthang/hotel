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
        public DataTable GetByID(int intOrderID)
        {
            return objDAO.GetByID(intOrderID);
        }
    }
}
