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
    }
}
