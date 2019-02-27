using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GPSendingDeleteCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForScDetails, string GPNumber, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteGPSendingMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeleteGPSendingDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForScDetails));
                sqlCommand.Parameters.Add(AddParameter("@GPNumber", SsDbType.VarChar, ParameterDirection.Input, GPNumber));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
