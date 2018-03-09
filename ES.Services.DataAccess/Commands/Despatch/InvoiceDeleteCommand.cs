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
    public class InvoiceDeleteCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForInvoice, string DcNumber, string InvoiceNumber)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteInvoiceMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeleteInvoiceDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForInvoice));
                sqlCommand.Parameters.Add(AddParameter("@DCNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@InvoiceNumber", SsDbType.VarChar, ParameterDirection.Input, InvoiceNumber));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
