using ES.Services.DataAccess.Model.QueryModel.Stores;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GetReceivedDetailsSelectCommand : SsDbCommand
    {
        public GetGPReceivedDetailsQM Execute()
        {
            var response = new GetGPReceivedDetailsQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPReceivingDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetGPReceivedDetailsModel = reader.ToList<GetGPReceivedDetailsModel>();
                }
            }

            return response;
        }
    }
}
