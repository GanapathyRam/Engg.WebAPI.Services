using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class ScMasterCommonInsertCommand : SsDbCommand
    {
        public void Execute(DateTime SubContractDcDate, string SubContractDcNumber, decimal SubContractSentFor, string Vehicle, long VendorCode, string Remarks)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddScMasterCommon]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ScDate", SsDbType.DateTime, ParameterDirection.Input, SubContractDcDate));
                sqlCommand.Parameters.Add(AddParameter("@ScDCNumber", SsDbType.VarChar, ParameterDirection.Input, SubContractDcNumber));
                sqlCommand.Parameters.Add(AddParameter("@ScSentFor", SsDbType.Decimal, ParameterDirection.Input, SubContractSentFor));
                sqlCommand.Parameters.Add(AddParameter("@Vehicle", SsDbType.VarChar, ParameterDirection.Input, Vehicle));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.NVarChar, ParameterDirection.Input, Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
