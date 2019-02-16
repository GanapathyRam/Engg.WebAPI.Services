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
    public class GPSendingMasterInsertCommand : SsDbCommand
    {
        public void Execute(string GPType, string GPNumber, Int64 VendorCode, DateTime GPDate, string RequestedBy, string Remarks, Guid CreateBy, DateTime CreatedDateTime)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddGPSendingMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GPType", SsDbType.VarChar, ParameterDirection.Input, GPType));
                sqlCommand.Parameters.Add(AddParameter("@GPNumber", SsDbType.VarChar, ParameterDirection.Input, GPNumber));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@GPDate", SsDbType.DateTime, ParameterDirection.Input, GPDate));
                sqlCommand.Parameters.Add(AddParameter("@RequestedBy", SsDbType.VarChar, ParameterDirection.Input, RequestedBy));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, CreateBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, CreatedDateTime));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
