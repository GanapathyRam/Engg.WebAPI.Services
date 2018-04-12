using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Production
{
    public class JobCardMasterAndDetailsInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForJobCardMaster, DataTable dataTableForJobCardDetails)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddJobCardMasterAndDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@JobCardMaster", SsDbType.Structured, ParameterDirection.Input, dataTableForJobCardMaster));
                sqlCommand.Parameters.Add(AddParameter("@JobCarDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForJobCardDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
