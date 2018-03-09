using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Framework.DataAccess.Extentions;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderSelectCommand : SsDbCommand
    {
        public GetWorkOrderQM Execute()
        {
            var response = new GetWorkOrderQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.getWorkOrderModel = reader.ToList<GetWorkOrderModel>();
                }
            }
            return response;
        }
    }
}
