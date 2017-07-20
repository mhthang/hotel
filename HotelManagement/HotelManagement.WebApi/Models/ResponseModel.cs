using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insite.Web.Models
{
    public class ResponseModel
    {
        
        public string ErrorMessage { get; set; }
        public string DataTable { get; set; }
        public object Result { get; set; }

        public ResponseModel(string strErrorMessage, string strDataTable, object objResult)
        {
            ErrorMessage = strErrorMessage;
            DataTable = strDataTable;
            Result = objResult;
        }
    }
}