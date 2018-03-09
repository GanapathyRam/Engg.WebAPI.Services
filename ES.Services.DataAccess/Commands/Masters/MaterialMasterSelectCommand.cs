using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using ES.Services.DataAccess.Model.CommandModel.Masters;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class MaterialMasterSelectCommand : SsDbCommand
    {
        public GetMaterialMasterQM Execute()
        {
            var response = new GetMaterialMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetMaterialMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@MaterialCode", SsDbType.Int, ParameterDirection.Input, Convert.ToInt32(model.MaterialCode)));
                //sqlCommand.Parameters.Add(AddParameter("@PageSize", SsDbType.Int, ParameterDirection.Input, model.PageSize));
                //sqlCommand.Parameters.Add(AddParameter("@PageIndex", SsDbType.Int, ParameterDirection.Input, model.PageIndex));
                sqlCommand.Parameters.Add(AddParameter("@RecordCount", SsDbType.Int, ParameterDirection.Output, default(int)));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.MaterialMasterList = reader.ToList<MaterialMasterModel>();
                }
                response.RecordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
            }
            return response;
        }
    }
}
