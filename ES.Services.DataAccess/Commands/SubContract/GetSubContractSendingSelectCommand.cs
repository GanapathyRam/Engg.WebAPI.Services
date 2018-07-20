using ES.Services.DataAccess.Model.QueryModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.SubContract;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class GetSubContractSendingSelectCommand : SsDbCommand
    {
        public GetSubContractSendingResponseQM Execute()
        {
            var response = new GetSubContractSendingResponseQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetSubContractSendingDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getSubContractSendingResponseModel = reader.ToList<GetSubContractSendingResponseModel>();
                }
            }
            return response;
        }
    }
}
