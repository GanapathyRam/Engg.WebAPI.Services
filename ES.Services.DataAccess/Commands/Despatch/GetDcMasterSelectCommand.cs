using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDcMasterSelectCommand : SsDbCommand
    {
        public GetDcMasterQM Execute()
        {
            var response = new GetDcMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDcMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetDcMasterModelList = reader.ToList<GetDcMasterModel>();
                }
            }

            return response;
        }
    }
}
