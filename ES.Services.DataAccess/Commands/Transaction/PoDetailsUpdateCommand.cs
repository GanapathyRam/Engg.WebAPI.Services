using ES.Services.DataAccess.Model.CommandModel.Transaction;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class PoDetailsUpdateCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForWorkOrderDetails, UpdatePoDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdatePODetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@UpdatePurchaseOrderDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForWorkOrderDetails));
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
