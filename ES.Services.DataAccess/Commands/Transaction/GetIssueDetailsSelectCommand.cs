using ES.Services.DataAccess.Model.QueryModel.Transaction;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class GetIssueDetailsSelectCommand : SsDbCommand
    {
        public GetIssueDetailsQM Execute()
        {
            var response = new GetIssueDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetIssuesDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetIssueDetailsModelList = reader.ToList<GetIssueDetailsModel>();
                }
            }

            return response;
        }
    }
}
