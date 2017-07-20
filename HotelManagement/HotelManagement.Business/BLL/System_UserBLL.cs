using HotelManagement.Business.DAO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

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
            return objDAO.Delete(strUsername, strUserlogin);
        }

        public bool Login(string strUsername, string strPassword)
        {
            bool IsLogin = false;
            DataTable dt = objDAO.Login(strUsername, this.ToMD5(strPassword));
            if (dt.Rows.Count > 0)
            {
                IsLogin = true;
            }
            return IsLogin;
        }

        public bool ChangePassword(string strUsername, string strPassword)
        {
            return objDAO.ChangePassword(strUsername, strPassword);
        }

        public string ToMD5(string str)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }
            return sbHash.ToString();

        }
    }
}