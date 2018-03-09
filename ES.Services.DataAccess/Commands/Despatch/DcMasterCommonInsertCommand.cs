using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class DcMasterCommonInsertCommand : SsDbCommand
    {
        public void Execute(string WoType, string DcNumber, DateTime DcDate, Int64 VendorCode, string DcType, string VehicleNo, bool Billable)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddDcMasterCommon]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WoType", SsDbType.VarChar, ParameterDirection.Input, WoType));
                sqlCommand.Parameters.Add(AddParameter("@DcDate", SsDbType.DateTime, ParameterDirection.Input, DcDate));
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@DcType", SsDbType.VarChar, ParameterDirection.Input, DcType));
                sqlCommand.Parameters.Add(AddParameter("@Billable", SsDbType.Bit, ParameterDirection.Input, Billable));
                sqlCommand.Parameters.Add(AddParameter("@VehicleNo", SsDbType.VarChar, ParameterDirection.Input, VehicleNo));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
