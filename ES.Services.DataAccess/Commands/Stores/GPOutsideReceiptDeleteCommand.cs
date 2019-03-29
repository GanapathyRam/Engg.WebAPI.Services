using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GPOutsideReceiptDeleteCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForScDetails, string GPOutsideReceiptNumber, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteGPOutsideReceiptMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeleteGPOutsideReceiptDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForScDetails));
                sqlCommand.Parameters.Add(AddParameter("@GPOutsideReceiptNumber", SsDbType.VarChar, ParameterDirection.Input, GPOutsideReceiptNumber));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
