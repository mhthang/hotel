using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGDD.Library.Data;

namespace HotelManagement.Business.DAO
{
    public class System_UserDAO
    {
        /// <summary>
        /// Lấy tất cả các user có filter
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(string strFullName,int intPositionID,string strIDNo,string strPhone)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_Select");
                objData.AddParameter("@Fullname",strFullName);
                objData.AddParameter("@PositionID", intPositionID);
                objData.AddParameter("@IDNo", strFullName);
                objData.AddParameter("@Phone", strPhone);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
        }
        /// <summary>
        /// Lấy user theo username
        /// </summary>
        /// <returns></returns>
        public DataTable GetByUsername(string strUsername)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_Select");
                objData.AddParameter("@Username", strUsername);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
        }
        /// <summary>
        /// Thêm/ cập nhật phòng
        /// </summary>
        /// <returns></returns>
        public int Insert_Update(string strUsername,string Fullname,int Position,string Phone,string Address, string Image, string Note, string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_Update");
                objData.AddParameter("@Username", strUsername);
                objData.AddParameter("@Fullname", Fullname);
                objData.AddParameter("@PositionID", Position);
                objData.AddParameter("@Image", Image);
                objData.AddParameter("@Address", Address);
                objData.AddParameter("@Phone",Phone);
                objData.AddParameter("@Note", Note);
                objData.AddParameter("@Userlogin", Userlogin);
                objData.ExecNonQuery();
                return 1;
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
        }
        /// <summary>
        /// Xóa user
        /// </summary>
        /// <returns></returns>
        public int Delete(string strUsername, string strUserlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_Delete");
                objData.AddParameter("@Username", strUsername);
                objData.AddParameter("@Userlogin", strUserlogin);
                objData.ExecNonQuery();
                return 1;
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
        }
        public DataTable Login(string strUsername, string strPassword)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_Login");
                objData.AddParameter("@Username", strUsername);
                objData.AddParameter("@Password", strPassword);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
        }

        public bool ChangePassword(string strUsername, string strPassword)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("System_User_ChangePassword");
                objData.AddParameter("@Username", strUsername);
                objData.AddParameter("@Password", strPassword);
                objData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                return false;
                throw objEx;
            }
            finally
            {
                objData.Disconnect();
            }
            
        }
    }
}
