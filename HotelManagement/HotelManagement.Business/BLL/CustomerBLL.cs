using HotelManagement.Business.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.BLL
{
    public class CustomerBLL
    {
        CustomerDAO objDAO = new CustomerDAO();
        public DataTable GetAll(string strKeyword, string strPhone, int intPageSize, int intPageIndex)
        {
            return objDAO.GetAll(strKeyword, strPhone, intPageSize, intPageIndex);
        }

        public DataTable GetByID(int ID)
        {
            return objDAO.GetByID(ID);
        }

        //public int Insert_Update(int ID, string RoomName, int Quantity, string Note, string Userlogin)
        //{
        //    return objDAO.Insert_Update();
        //}
        public int Delete(int ID, string Userlogin)
        {
            return objDAO.Delete(ID, Userlogin);
        }
    }
}
