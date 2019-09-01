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
    public class IssueMasterAndDetailsDeleteCommand : SsDbCommand
    {
        public void Execute(string IssueNumber, decimal IssueSerialNo, DataTable dataTableForIssueDetailsDelete, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteIssueMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@IssueNumber", SsDbType.NVarChar, ParameterDirection.Input, IssueNumber));
                sqlCommand.Parameters.Add(AddParameter("@IssueSerial", SsDbType.Decimal, ParameterDirection.Input, IssueSerialNo));
                sqlCommand.Parameters.Add(AddParameter("@DeleteIssueDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForIssueDetailsDelete));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
