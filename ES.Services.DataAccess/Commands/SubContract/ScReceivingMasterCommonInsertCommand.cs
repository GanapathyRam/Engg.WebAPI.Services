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
    public class ScReceivingMasterCommonInsertCommand : SsDbCommand
    {
        public void Execute(DateTime ScReceivingDcDate, string ScReceivingDcNumber, Int64 VendorCode, string VendorDCNumber, DateTime ScReceivingVendorDate, string Vehicle, string Remarks)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddScReceivingMasterCommon]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ScReceivingDate", SsDbType.DateTime, ParameterDirection.Input, ScReceivingDcDate));
                sqlCommand.Parameters.Add(AddParameter("@ScReceivingDCNumber", SsDbType.VarChar, ParameterDirection.Input, ScReceivingDcNumber));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@VendorDCNumber", SsDbType.VarChar, ParameterDirection.Input, VendorDCNumber));
                sqlCommand.Parameters.Add(AddParameter("@ScReceivingVendorDCDate", SsDbType.DateTime, ParameterDirection.Input, ScReceivingVendorDate));
                sqlCommand.Parameters.Add(AddParameter("@Vehicle", SsDbType.NVarChar, ParameterDirection.Input, Vehicle == null ? "" : Vehicle));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.NVarChar, ParameterDirection.Input, Remarks == null ? "" : Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
