using ES.Services.DataAccess.Model.CommandModel.Sales;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderHeatSelectCommand : SsDbCommand
    {
        public GetWorkOrderHeatDetailsQM Execute(String WorkOrderNumber)
        {
            var response = new GetWorkOrderHeatDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderHeatDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.VarChar, ParameterDirection.Input, WorkOrderNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getWorkOrderHeatDetails = reader.ToList<GetWorkOrderHeatModel>();
                }
            }
            return response;
        }
    }
}
