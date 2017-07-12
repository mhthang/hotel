using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGDD.Library.Data;

namespace HotelManagement.Business.DAO
{
    public class OrderDAO
    {
        /// <summary>
        /// Lấy tất cả các phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("HO_GoldenBoard_GetByType");
                objData.AddParameter("");
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
        /// Lấy phòng theo ID
        /// </summary>
        /// <returns></returns>
        public DataTable GetByID(int intOrderID)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("HO_GoldenBoard_GetByType");
                objData.AddParameter("@OrderID", intOrderID);
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
        public int Insert_Update(int intOrderID,int intCustomerID,DateTime CheckinDate,DateTime CheckOutDate,int Status,string Note,string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("HO_GoldenBoard_GetByType");
                objData.AddParameter("@OrderID", intOrderID);
                objData.AddParameter("@CustomerID", intCustomerID);
                objData.AddParameter("@CheckinDate", CheckinDate);
                objData.AddParameter("@CheckOutDate", CheckOutDate);
                objData.AddParameter("@Status", Status);
                objData.AddParameter("@Note",Note);
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
        /// Xóa phòng
        /// </summary>
        /// <returns></returns>
        public int Delete(int intOrderID,string strUserlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("HO_GoldenBoard_GetByType");
                objData.AddParameter("@OrderID", intOrderID);
                objData.AddParameter("@DeletedBy", strUserlogin);
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
    }
}
