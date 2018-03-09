using ES.Services.DataAccess.Model.CommandModel.Sales;
using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderDetailsStatusSelectCommand : SsDbCommand
    {
        public GetWorkOrderDetailsStatusQM Execute(GetWorkOrderDetailsStatusCM modelCM)
        {
            var response = new GetWorkOrderDetailsStatusQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderDetailsStatus]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.VarChar, ParameterDirection.Input, modelCM.WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.Decimal, ParameterDirection.Input, modelCM.WorkOrderSerial));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        response.Dc = Convert.ToBoolean(reader["Dc"]);
                        response.Invoice = Convert.ToBoolean(reader["Invoice"]);
                        response.SubContract = Convert.ToBoolean(reader["SubContract"]);
                        response.JTC = Convert.ToBoolean(reader["JTC"]);
                    }
                }
            }
            return response;
        }
    }
}
