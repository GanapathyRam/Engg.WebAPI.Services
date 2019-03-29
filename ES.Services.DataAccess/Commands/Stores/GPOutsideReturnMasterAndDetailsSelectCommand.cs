using ES.Services.DataAccess.Model.QueryModel.Stores;
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
    public class GPOutsideReturnMasterAndDetailsSelectCommand : SsDbCommand
    {
        public GetGPOutsideReturnQM Execute()
        {
            var response = new GetGPOutsideReturnQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPOutsideReturnMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getGPOutsideReturnList = reader.ToList<GetGPOutsideReturnModel>();
                }
            }
            return response;
        }
    }
}
