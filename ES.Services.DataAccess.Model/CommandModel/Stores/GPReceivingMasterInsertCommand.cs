using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Stores
{
    public class GPReceivingMasterInsertCommand : SsDbCommand
    {
        public void Execute(string GPReceiptNumber, DateTime GPReceiptDate, Int64 VendorCode, string DocumentID, DateTime DocumentDate, string Remarks, Guid CreateBy, DateTime CreatedDateTime)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPReceivingMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPReceiptNumber", SsDbType.VarChar, ParameterDirection.Input, GPReceiptNumber));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@GPReceiptDate", SsDbType.DateTime, ParameterDirection.Input, GPReceiptDate));
                sqlCommand.Parameters.Add(AddParameter("@DocumentID", SsDbType.VarChar, ParameterDirection.Input, DocumentID));
                sqlCommand.Parameters.Add(AddParameter("@DocumentDate", SsDbType.DateTime, ParameterDirection.Input, DocumentDate));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, CreateBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, CreatedDateTime));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
