using ES.Services.DataAccess.Model.QueryModel.Production;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Production
{
    public class GetProcessCardCopySelectCommand : SsDbCommand
    {
        public GetProcesssCardCopyQM Execute()
        {
            var response = new GetProcesssCardCopyQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetCopyProcessCardDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetProcesssCardCopyQMModel = reader.ToList<GetProcesssCardCopyQMModel>();
                }
            }
            return response;
        }
    }
}
