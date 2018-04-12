using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Production;

namespace ES.Services.DataAccess.Commands.Production
{
    public class GetJobCardGenerationSelectCommand : SsDbCommand
    {
        public GetJobCardGenerationQM Execute()
        {
            var response = new GetJobCardGenerationQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetJobCardMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetJobCardGenerationModelList = reader.ToList<GetJobCardGenerationModel>();
                }
            }
            return response;
        }
    }
}
