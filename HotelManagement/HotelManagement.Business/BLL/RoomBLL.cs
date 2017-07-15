using HotelManagement.Business.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.BLL
{
    public class RoomBLL
    {
        RoomDAO objDAO = new RoomDAO();
        public DataTable GetAll(string RoomName, int PageSize, int PageIndex)
        {
            return objDAO.GetAll(RoomName, PageSize, PageIndex);
        }

        public DataTable GetByID(int ID)
        {
            return objDAO.GetByID(ID);
        }

        public int Insert_Update(int ID, string RoomName, int Quantity, string Note, string Userlogin)
        {
            return objDAO.Insert_Update(ID, RoomName, Quantity, Note, Userlogin);
        } 
        public int Delete(int ID, string Userlogin)
        {
            return objDAO.Delete(ID, Userlogin);
        }

        public DataTable GetRoomOrderByStatus(int intStatus, int intPageSize, int intPageIndex)
        {
            return objDAO.GetRoomOrderByStatus(intStatus,intPageSize,intPageIndex);
        }
    }
}
