using ES.Services.DataAccess.Model.CommandModel.Stores;
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
    class GPSendingDetailsInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForGPSendingDetails, GPSendingDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPSendingDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPSendingDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForGPSendingDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
