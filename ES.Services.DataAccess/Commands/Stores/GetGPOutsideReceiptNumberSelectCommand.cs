using SS.Framework.DataAccess;
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
    public class GetGPOutsideReceiptNumberSelectCommand : SsDbCommand
    {
        public string Execute(string gpOutsideType)
        {
            string GPOutsideReceiptNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPOutsideReceiptNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideType", SsDbType.VarChar, ParameterDirection.Input, gpOutsideType));
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        GPOutsideReceiptNumber = Convert.ToString(reader["GPOutsideReceiptNumber"]);
                    }
                }
            }
            return GPOutsideReceiptNumber;
        }
    }
}
