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
    public class GetInvoiceDetailsSelectCommand : SsDbCommand
    {
        public GetInvoiceDetailsQM Execute(string InvoiceNumber)
        {
            var response = new GetInvoiceDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetInvoiceDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InvoiceNumber", SsDbType.NVarChar, ParameterDirection.Input, InvoiceNumber));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetSavedInvoiceDetailsList = reader.ToList<SavedInvoiceDetailsQMModel>();
                }
            }
            return response;
        }
    }
}
