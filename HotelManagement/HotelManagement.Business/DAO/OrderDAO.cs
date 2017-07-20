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
                objData.CreateNewStoredProcedure("OrderDetail_SelectByID");
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
        public int Insert_Update(int intOrderID,int intRoomID,int intCustomerID,string strCustomerName,string strPhone,string strAddress,string strIDNo,string strEmail, DateTime CheckinDate,DateTime CheckOutDate,int intQuantityPeople, string Note,string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Order_Create_Update");
                objData.AddParameter("@OrderID", intOrderID);
                objData.AddParameter("@CustomerID", intCustomerID);
                objData.AddParameter("@CheckinDate", CheckinDate);
                if (CheckOutDate != null && CheckOutDate != DateTime.MinValue)
                    objData.AddParameter("@CheckOutDate", CheckOutDate);
                objData.AddParameter("@QuantityPeople", intQuantityPeople);
                objData.AddParameter("@CustomerName", strCustomerName);
                objData.AddParameter("@RoomID", intRoomID);
                objData.AddParameter("@Phone", strPhone);
                objData.AddParameter("@Address", strAddress);
                objData.AddParameter("@IDNo",strIDNo);
                objData.AddParameter("@Email",strEmail);
                objData.AddParameter("@Note",Note);
                objData.AddParameter("@Userlogin", Userlogin);
                return Convert.ToInt32(objData.ExecStoreToString());
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


        public int InsertDetail(int intOrderID, int intProductID, int intQuantity,double dPrice, string Note, string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("OrderDetail_Insert");
                objData.AddParameter("@OrderID", intOrderID);
                objData.AddParameter("@ProductID", intProductID);
                objData.AddParameter("@Quantity", intQuantity);
                objData.AddParameter("@Price", dPrice);
                objData.AddParameter("@Note", Note);
                objData.AddParameter("@Userlogin", Userlogin);
                return objData.ExecNonQuery();
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

        /// <summary>
        /// Xóa phòng
        /// </summary>
        /// <returns></returns>
        public int OrderDetail_Delete(int intOrderID, string strUserlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Product_Delete");
                objData.AddParameter("@ID", intOrderID);
                objData.AddParameter("@Userlgon", strUserlogin);
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
