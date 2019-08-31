using ES.Services.DataAccess.Model.CommandModel.Transaction;
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
    public class IssueMasterInsertCommand : SsDbCommand
    {
        public void Execute(AddIssueMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddIssueMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@IssueNumber", SsDbType.VarChar, ParameterDirection.Input, model.IssueNumber));
                sqlCommand.Parameters.Add(AddParameter("@IssueDate", SsDbType.DateTime, ParameterDirection.Input, model.IssueDate));
                sqlCommand.Parameters.Add(AddParameter("@DepartmentCode", SsDbType.Decimal, ParameterDirection.Input, model.DepartmentCode));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, model.Remarks));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, Guid.NewGuid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
