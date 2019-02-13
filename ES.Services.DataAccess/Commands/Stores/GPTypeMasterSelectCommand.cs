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
    public class GPTypeMasterSelectCommand : SsDbCommand
    {
        public GPTypeMasterQM Execute()
        {
            var response = new GPTypeMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetGPTypeMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.gpTypeList = reader.ToList<GPTypeMasterResponseModel>();
                }
            }
            return response;
        }
    }
}
