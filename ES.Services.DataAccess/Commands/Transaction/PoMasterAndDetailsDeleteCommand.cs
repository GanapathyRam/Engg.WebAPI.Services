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
    public class PoMasterAndDetailsDeleteCommand : SsDbCommand
    {
        public void Execute(string PONumber, decimal PoSerialNo, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeletePoMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PONumber", SsDbType.Structured, ParameterDirection.Input, PONumber));
                sqlCommand.Parameters.Add(AddParameter("@POSerial", SsDbType.VarChar, ParameterDirection.Input, PoSerialNo));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
