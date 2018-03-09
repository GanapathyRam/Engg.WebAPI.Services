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
    public class WorkOrderNumberClientSerialNoSelectCommand : SsDbCommand
    {
        public string Execute()
        {
            //var response = new GetWorkOrderTypeQM();
            string WorkOrderSerialNo = string.Empty;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderClientSerialNo]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        WorkOrderSerialNo = Convert.ToString(reader["SerialNo"]);
                    }
                }
            }
            return WorkOrderSerialNo;
        }
    }
}
