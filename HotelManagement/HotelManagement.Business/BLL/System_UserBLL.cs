using HotelManagement.Business.DAO;
using System.Data;

namespace HotelManagement.Business.BLL
{
    public class System_UserBLL
    {
        private System_UserDAO objDAO = new System_UserDAO();

        public DataTable GetAll(string strFullName, int intPositionID, string strIDNo, string strPhone)
        {
            return objDAO.GetAll(strFullName, intPositionID, strIDNo, strPhone);
        }

        public DataTable GetByUsername(string strUsername)
        {
            return objDAO.GetByUsername(strUsername);
        }

        public int Insert_Update(string strUsername, string Fullname, int Position, string Phone, string Address, string Image, string Note, string Userlogin)
        {
            return objDAO.Insert_Update(strUsername, Fullname, Position, Phone, Address, Image, Note, Image);
        }
        public int Delete(string strUsername, string strUserlogin)
        {
            return objDAO.Delete(strUsername,strUserlogin);
        }
    }
}