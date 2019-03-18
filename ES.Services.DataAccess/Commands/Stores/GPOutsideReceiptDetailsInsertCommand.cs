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
    public class GPOutsideReceiptDetailsInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForGPSendingDetails, GPOutsideReceiptDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPOutsideReceiptDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReceiptUdt", SsDbType.Structured, ParameterDirection.Input, dataTableForGPSendingDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
