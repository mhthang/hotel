using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGDD.Library.Data;

namespace HotelManagement.Business.DAO
{
    public class ProductDAO
    {
        public DataTable GetAll(string strKeyword, int intPageSize, int intPageIndex)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Product_SelectAll");
                objData.AddParameter("@Keyword", strKeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
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
        public DataTable GetGroupByOrderID(int intOderID)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Product_SelectAll");
                objData.AddParameter("@OrderID", intOderID);
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

        public int Insert_Update(int ProductID,string ProductName, int Price, int Unit, string Note, string Userlogin)
        {
            IData objData = Data.CreateData();
            try
            {
                objData.Connect();
                objData.CreateNewStoredProcedure("Product_Insert");
                objData.AddParameter("@ProductID", ProductID);
                objData.AddParameter("@ProductName", ProductName);
                objData.AddParameter("@Price", Price);
                objData.AddParameter("@Unit", Unit);
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
    }
}
