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
    public class VendorMasterSelectCommand: SsDbCommand
    {
        public GetVendorMasterQM Execute()
        {
            var response = new GetVendorMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetVendorMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@UserID", SsDbType.Int, ParameterDirection.Input, model.UserId));
                //sqlCommand.Parameters.Add(AddParameter("@PageSize", SsDbType.Int, ParameterDirection.Input, model.PageSize));
                //sqlCommand.Parameters.Add(AddParameter("@PageIndex", SsDbType.Int, ParameterDirection.Input, model.PageIndex));
                sqlCommand.Parameters.Add(AddParameter("@RecordCount", SsDbType.Int, ParameterDirection.Output, default(int)));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.VendorMasterList = reader.ToList<VendorMasterModel>();
                }
                response.RecordCount = Convert.ToInt32(sqlCommand.Parameters["@RecordCount"].Value);
            }
            return response;
        }
    }
}
