using ES.Services.DataAccess.Model.QueryModel.Sales;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Extentions;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
   public class WorkOrderNumberForHeatSelectCommand : SsDbCommand
    {
        public GetWorkOrderNumberForHeatQM Execute()
        {
            var response = new GetWorkOrderNumberForHeatQM() {
              
            };
            var responseDtoList = new List<GetWorkOrderNumberHeatModelQM>();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderNumberForHeat]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
           
              
                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                   
                    while (reader.Read())
                    {
                        var responseDto = new GetWorkOrderNumberHeatModelQM() {
                            WONumber = reader["WONumber"].ToString()
                        };

                    responseDtoList.Add(responseDto);
                    }

                }
                response.getWorkOrderNumberHeatDetails = responseDtoList;
            }
            return response;
        }
    }
}
