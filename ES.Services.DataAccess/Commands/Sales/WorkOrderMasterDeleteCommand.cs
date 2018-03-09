using ES.Services.DataAccess.Model.CommandModel.Sales;
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
    public class WorkOrderMasterDeleteCommand : SsDbCommand
    {
        public void Execute(GetWorkOrderDetailsStatusCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteWorkOrderMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.NVarChar, ParameterDirection.Input, model.WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.Decimal, ParameterDirection.Input, model.WorkOrderSerial));
               
                //sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                //sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
