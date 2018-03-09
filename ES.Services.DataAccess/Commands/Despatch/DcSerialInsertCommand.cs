using ES.Services.DataAccess.Model.CommandModel.Despatch;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class DcSerialInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForWorkOrderDetails, DcDetailSerialCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddDcSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DcSerial", SsDbType.Structured, ParameterDirection.Input, dataTableForWorkOrderDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
