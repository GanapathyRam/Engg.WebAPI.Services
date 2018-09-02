using ES.Services.DataAccess.Model.QueryModel.Despatch;
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

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDimensionReportSelectCommand : SsDbCommand
    {
        public GetDimensionReportQM Execute(string InvoiceNumber, decimal InvoiceSerial, int IsReportFor)
        {
            var response = new GetDimensionReportQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDimensionCardEntryReport]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InvoiceNumber", SsDbType.NVarChar, ParameterDirection.Input, InvoiceNumber));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceSerial", SsDbType.Decimal, ParameterDirection.Input, InvoiceSerial));
                sqlCommand.Parameters.Add(AddParameter("@IsReportFor", SsDbType.Int, ParameterDirection.Input, IsReportFor));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getDimensionReportModel = reader.ToList<GetDimensionReportModel>();
                }
            }

            return response;
        }
    }
}
