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
    public class WorkOrderDetailsInsertCommand : SsDbCommand
    {
        public void Execute(WorkOrderDetailsCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddWorkOrderDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.VarChar, ParameterDirection.Input, model.WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.Decimal, ParameterDirection.Input, model.WorkOrderSerial));
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.VarChar, ParameterDirection.Input, model.SerialNo));
                sqlCommand.Parameters.Add(AddParameter("@HeatNo", SsDbType.VarChar, ParameterDirection.Input, model.HeatNo));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, model.CreatedDateTime));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
