using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using SS.Framework.DataAccess.Extentions;
using System.Data;
using System;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class MaterialMasterListSelectCommand : SsDbCommand
    {
        public GetMaterialMasterListQM Execute()
        {
            var response = new GetMaterialMasterListQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetMaterialMasterList]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@PageSize", SsDbType.Int, ParameterDirection.Input, model.PageSize));
                //sqlCommand.Parameters.Add(AddParameter("@PageIndex", SsDbType.Int, ParameterDirection.Input, model.PageIndex));
                sqlCommand.Parameters.Add(AddParameter("@RecordCount", SsDbType.Int, ParameterDirection.Output, default(int)));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.MaterialMasterList = reader.ToList<MaterialMasterListForDropDown>();
                }
                response.RecordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
            }
            return response;
        }
    }
}
