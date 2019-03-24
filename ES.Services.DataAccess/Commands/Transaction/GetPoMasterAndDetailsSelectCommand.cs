using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Framework.DataAccess.Extentions;
using ES.Services.DataAccess.Model.QueryModel.Transaction;

namespace ES.Services.DataAccess.Commands.Transaction
{
    public class GetPoMasterAndDetailsSelectCommand : SsDbCommand
    {
        public GetPoResponseQM Execute()
        {
            var response = new GetPoResponseQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetPoMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.GetPoResponseModelList = reader.ToList<GetPoResponseModel>();
                }
            }

            return response;
        }
    }
}
