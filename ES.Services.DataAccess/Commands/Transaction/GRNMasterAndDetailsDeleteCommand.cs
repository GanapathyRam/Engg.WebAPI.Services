using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class GRNMasterAndDetailsDeleteCommand : SsDbCommand
    {
        public void Execute(string GRNNumber, decimal GRNSerialNo, DataTable dataTableForGRNDetailsDelete, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteGRNMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GRNNumber", SsDbType.NVarChar, ParameterDirection.Input, GRNNumber));
                sqlCommand.Parameters.Add(AddParameter("@GRNSerial", SsDbType.Decimal, ParameterDirection.Input, GRNSerialNo));
                sqlCommand.Parameters.Add(AddParameter("@DeleteGRNDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForGRNDetailsDelete));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
