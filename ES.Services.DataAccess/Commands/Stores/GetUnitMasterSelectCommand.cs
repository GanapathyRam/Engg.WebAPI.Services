using ES.Services.DataAccess.Model.QueryModel.Stores;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Stores
{
    public class GetUnitMasterSelectCommand : SsDbCommand
    {
        public GetUnitMasterQM Execute()
        {
            var response = new GetUnitMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetUnitMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetUnitMasterQMList = reader.ToList<GetUnitMasterQMList>();
                }
            }
            return response;
        }
    }
}
