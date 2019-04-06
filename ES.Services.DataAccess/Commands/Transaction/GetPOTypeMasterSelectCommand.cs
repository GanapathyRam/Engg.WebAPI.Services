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
    public class GetPOTypeMasterSelectCommand : SsDbCommand
    {
        public GetPOTypeQM Execute()
        {
            var response = new GetPOTypeQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetPOTypeMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetPOTypeModelList = reader.ToList<GetPOTypeModel>();
                }
            }

            return response;
        }
    }
}
