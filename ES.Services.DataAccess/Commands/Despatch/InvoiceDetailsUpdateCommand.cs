using ES.Services.DataAccess.Model.CommandModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    class InvoiceDetailsUpdateCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForInvoiceDetails, InvoiceDetailCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateInvoiceDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InvoiceDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForInvoiceDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
