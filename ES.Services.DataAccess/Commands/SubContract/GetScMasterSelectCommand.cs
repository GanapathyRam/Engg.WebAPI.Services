using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.SubContract;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class GetScMasterSelectCommand : SsDbCommand
    {
        public GetScMasterQM Execute()
        {
            var response = new GetScMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSCMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetScMasterModelList = reader.ToList<GetScMasterModel>();
                }
            }

            return response;
        }
    }
}
