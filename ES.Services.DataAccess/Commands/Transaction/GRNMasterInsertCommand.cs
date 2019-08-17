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
    public class GRNMasterInsertCommand : SsDbCommand
    {
        public void Execute(AddGRNMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGRNMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GRNNumber", SsDbType.VarChar, ParameterDirection.Input, model.GRNNumber));
                sqlCommand.Parameters.Add(AddParameter("@GRNDate", SsDbType.DateTime, ParameterDirection.Input, model.GRNDate));
                sqlCommand.Parameters.Add(AddParameter("@ReceivedDate", SsDbType.DateTime, ParameterDirection.Input, model.ReceivedDate));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, model.VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceNumber", SsDbType.VarChar, ParameterDirection.Input, model.InvoiceNumber));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceDate", SsDbType.DateTime, ParameterDirection.Input, model.InvoiceDate));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, Guid.NewGuid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
