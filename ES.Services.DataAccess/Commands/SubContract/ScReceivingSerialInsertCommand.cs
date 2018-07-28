using ES.Services.DataAccess.Model.CommandModel.SubContract;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class ScReceivingSerialInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForWorkOrderDetails, ScReceivingDetailSerialCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddScReceivingDetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ScReceivingSerial", SsDbType.Structured, ParameterDirection.Input, dataTableForWorkOrderDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
