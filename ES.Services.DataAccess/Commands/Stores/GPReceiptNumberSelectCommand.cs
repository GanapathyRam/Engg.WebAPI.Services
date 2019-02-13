using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
   public class GPReceiptNumberSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            string GPReceiptNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPReceiptNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        GPReceiptNumber = Convert.ToString(reader["GPReceiptNumber"]);
                    }
                }
            }
            return GPReceiptNumber;
        }
    }
}
