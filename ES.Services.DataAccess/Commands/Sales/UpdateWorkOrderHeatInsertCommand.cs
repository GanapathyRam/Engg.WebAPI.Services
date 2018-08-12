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
    public class UpdateWorkOrderHeatInsertCommand : SsDbCommand
    {
        public void Execute(UpdateWorkOrderHeatCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateWorkOrderHeat]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.NVarChar, ParameterDirection.Input, model.WONumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.Decimal, ParameterDirection.Input, model.WOSerial));
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.NVarChar, ParameterDirection.Input, model.SerialNo));
                sqlCommand.Parameters.Add(AddParameter("@HeatNo", SsDbType.NVarChar, ParameterDirection.Input, model.HeatNo));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
