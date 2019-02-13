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
   public class GPSendingNumberSelectCommand : SsDbCommand
    {
        public string Execute(string gpType)
        {
            string GPNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPSendingNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GpType", SsDbType.VarChar, ParameterDirection.Input, gpType));
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        GPNumber = Convert.ToString(reader["GPNumber"]);
                    }
                }
            }
            return GPNumber;
        }
    }
}
