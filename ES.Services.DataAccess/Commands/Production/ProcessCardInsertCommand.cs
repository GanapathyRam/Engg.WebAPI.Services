using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.CommandModel.Production;
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
    public class ProcessCardInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForProcessCardMaster, DataTable dataTableForProcessCardDetails, AddProcessCardCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddProcessCard]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ProcessCardMaster", SsDbType.Structured, ParameterDirection.Input, dataTableForProcessCardMaster));
                sqlCommand.Parameters.Add(AddParameter("@ProcessCardDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForProcessCardDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
