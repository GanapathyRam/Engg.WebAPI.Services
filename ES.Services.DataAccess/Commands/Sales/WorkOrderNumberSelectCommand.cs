using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderNumberSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            //var response = new GetWorkOrderTypeQM();
            string WorkOrderNumber = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderNumber]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        WorkOrderNumber = Convert.ToString(reader["WorkOrderNumber"]);
                    }
                }
            }
            return WorkOrderNumber;
        }
    }
}
