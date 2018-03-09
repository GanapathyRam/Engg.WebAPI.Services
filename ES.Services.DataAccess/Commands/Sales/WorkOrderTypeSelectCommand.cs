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
    public class WorkOrderTypeSelectCommand : SsDbCommand
    {
        public GetWorkOrderTypeQM Execute()
        {
            var response = new GetWorkOrderTypeQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderType]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    response.workOrderTypeModelList = reader.ToList<WorkOrderTypeModel>();
                }
            }
            return response;
        }
    }
}
