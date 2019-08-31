using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class IssuesNumberSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            string IssuesNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetIssueNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        IssuesNumber = Convert.ToString(reader["IssueNumber"]);
                    }
                }
            }
            return IssuesNumber;
        }
    }
}
