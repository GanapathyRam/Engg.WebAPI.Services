using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderMasterCommonInsertCommand : SsDbCommand
    {
        public void Execute(string WorkOrderType, string WorkOrderNumber, DateTime WorkOrderDate, Int64 VendorCode)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddWorkOrderMasterCommon]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WOType", SsDbType.VarChar, ParameterDirection.Input, WorkOrderType));
                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.VarChar, ParameterDirection.Input, WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WODate", SsDbType.DateTime, ParameterDirection.Input, WorkOrderDate));
                sqlCommand.Parameters.Add(AddParameter("@VendorCode", SsDbType.BigInt, ParameterDirection.Input, VendorCode));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
