using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;
using System;
using SS.Framework.DataAccess;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDcDetailsForInvoiceSelectCommand : SsDbCommand
    {
        public GetDcDetailsForInvoiceQM Execute(string DcNumber)
        {
            var response = new GetDcDetailsForInvoiceQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDcDetailsForInvoice]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.NVarChar, ParameterDirection.Input, DcNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetDcDetailsForInvoiceModel = reader.ToList<GetDcDetailsForInvoiceModel>();
                }
            }
            return response;
        }
    }
}
