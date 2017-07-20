using HotelManagement.Business.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.BLL
{
    public class ProductBLL
    {
        ProductDAO objDAO = new ProductDAO();
        public DataTable GetAll(string strKeyword, int intPageSize, int intPageIndex)
        {
            return objDAO.GetAll(strKeyword, intPageSize, intPageIndex);
        }
        public DataTable GetGroupByOrderID(int intOderID)
        {
            return objDAO.GetGroupByOrderID(intOderID);
        }
        public int Insert_Update(int ProductID, string ProductName, int Price, int Unit, string Note, string Userlogin)
        {
            return objDAO.Insert_Update(ProductID, ProductName, Price, Unit, Note, Userlogin);
        }
    }
}
