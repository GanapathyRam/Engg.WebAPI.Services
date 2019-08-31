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
    public class GetSavedIssueMasterAndDetailsSelectCommand : SsDbCommand
    {
        public GetIssueMasterAndDetailsQM Execute()
        {
            var response = new GetIssueMasterAndDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSavedIssueMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetIssueMasterAndDetailsModelList = reader.ToList<GetIssueMasterAndDetailsModel>();
                }
            }

            return response;
        }
    }
}
