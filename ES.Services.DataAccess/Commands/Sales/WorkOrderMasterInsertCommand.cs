using ES.Services.DataAccess.Model.CommandModel.Sales;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Sales
{
    public class WorkOrderMasterInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForWorkOrderDetails, AddWorkOrderCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddWorkOrderMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@WorkOrderMaster", SsDbType.Structured, ParameterDirection.Input, dataTableForWorkOrderDetails));             
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
