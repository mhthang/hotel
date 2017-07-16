using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace Insite.Bussiness.Repository
{
    public class DataHelper
    {
        public static string ConvertDataTableToString(DataTable dt, bool bolIsUpperColumnName = false)
        {
            var result = "";
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            var rows = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dt.Rows)
            {
                if (bolIsUpperColumnName)
                {
                    var row = dt.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName.ToUpper(), col => dr[col]);
                    rows.Add(row);
                }
                else
                {
                    var row = dt.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => dr[col]);
                    rows.Add(row);
                }
            }

            result = serializer.Serialize(rows);
            return result;
        }

    }
}
