using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Despatch;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class GetDcTypeSelectCommand : SsDbCommand
    {
        public GetDcTypeQM Execute()
        {
            var response = new GetDcTypeQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetDCType]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.dcTypeModelList = reader.ToList<DcTypeModel>();
                }
            }
            return response;
        }
    }
}
