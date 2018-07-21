using ES.Services.DataAccess.Model.CommandModel.Despatch;
using ES.Services.DataAccess.Model.CommandModel.SubContract;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.SubContract
{
    public class ScSerialInsertCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForWorkOrderDetails, ScDetailSerialCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddScDetailsSerial]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ScDCSerial", SsDbType.Structured, ParameterDirection.Input, dataTableForWorkOrderDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
