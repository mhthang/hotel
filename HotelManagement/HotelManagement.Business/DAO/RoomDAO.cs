using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGDD.Library.Data;

namespace HotelManagement.Business.DAO
{
    public class RoomDAO
    {
        /// <summary>
        /// Lấy tất cả các phòng
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(string RoomName,int PageSize, int PageIndex)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Room_SelectALL");
                objData.AddParameter("@RoomName", RoomName);
                objData.AddParameter("@PageSize", PageSize);
                objData.AddParameter("@PageIndex", PageIndex);
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
        public DataTable GetByID(int ID)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Room_SelectByID");
                objData.AddParameter("@ID", ID);
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
        public int Insert_Update(int ID, string RoomName, int Quantity, string Note, string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Room_Update");
                objData.AddParameter("@ID", ID);
                objData.AddParameter("@RoomName", RoomName);
                objData.AddParameter("@Quantity", Quantity);
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
        /// Xóa phòng
        /// </summary>
        /// <returns></returns>
        public int Delete(int ID, string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Room_Delete");
                objData.AddParameter("@ID",ID);
                objData.AddParameter("@Userlogin",Userlogin);
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

        public DataTable GetRoomOrderByStatus(int intStatus, int intPageSize, int intPageIndex)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Order_Product_SelectByType");
                objData.AddParameter("@Status", intStatus);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex",intPageIndex);
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
    }
}
