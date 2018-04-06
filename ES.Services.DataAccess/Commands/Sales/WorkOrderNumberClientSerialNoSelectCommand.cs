using ES.Services.DataAccess.Model.QueryModel.Despatch;
using ES.Services.DataAccess.Model.QueryModel.Sales;
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
        public GetWorkOrderClientSerialNoQM Execute()
        {
            //var response = new GetWorkOrderTypeQM();
            GetWorkOrderClientSerialNoQM workOrderSerialNo = new GetWorkOrderClientSerialNoQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetWorkOrderClientSerialNo]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var reader = SsDbCommandHelper.ExecuteReader(sqlCommand))
                {
                    if (reader.Read())
                    {
                        workOrderSerialNo = new GetWorkOrderClientSerialNoQM()
                        {
                            WorkOrderClientSerialNo = Convert.ToString(reader["SerialNo"]),
                            WorkOrderClientSerialChar = Convert.ToString(reader["SerialChar"]),
                        };
                    }
                }
            }
            return workOrderSerialNo;
        }
    }
}
