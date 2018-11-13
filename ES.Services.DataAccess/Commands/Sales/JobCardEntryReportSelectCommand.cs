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
    public class JobCardEntryReportSelectCommand : SsDbCommand
    {
        public GetJobCardEntryReportQM Execute(String WorkOrderNumber, string WoSerial)
        {
            var response = new GetJobCardEntryReportQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetJobCardEntryReport]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@WONumber", SsDbType.VarChar, ParameterDirection.Input, WorkOrderNumber));
                sqlCommand.Parameters.Add(AddParameter("@WOSerial", SsDbType.VarChar, ParameterDirection.Input, WoSerial));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        response.GetJobCardEntryReportModel = reader.ToList<GetJobCardEntryReportModel>();
                    }
                }
            }

            return response;
        }
    }
}
