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
    public class InvoiceDetailsSerialInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForInvoiceDetailsSerial, InvoiceDetailSerialCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddInvoiceDetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@InvoiceDetailsSerial", SsDbType.Structured, ParameterDirection.Input, dataTableForInvoiceDetailsSerial));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
