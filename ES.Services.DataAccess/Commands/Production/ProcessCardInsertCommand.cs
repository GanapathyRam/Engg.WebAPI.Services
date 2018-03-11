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
        public void Execute(decimal PartCode, decimal SequenceNumber, string MachineCode, string JigCode, string SettingTime,
            string RunningTime, DataTable dataTableForProcessCardDetails, AddProcessCardCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddProcessCard]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));
                sqlCommand.Parameters.Add(AddParameter("@SequenceNumber", SsDbType.Decimal, ParameterDirection.Input, SequenceNumber));
                sqlCommand.Parameters.Add(AddParameter("@MachineCode", SsDbType.VarChar, ParameterDirection.Input, MachineCode));
                sqlCommand.Parameters.Add(AddParameter("@JigCode", SsDbType.VarChar, ParameterDirection.Input, JigCode));
                sqlCommand.Parameters.Add(AddParameter("@SettingTime", SsDbType.VarChar, ParameterDirection.Input, SettingTime));
                sqlCommand.Parameters.Add(AddParameter("@RunningTime", SsDbType.VarChar, ParameterDirection.Input, RunningTime));
                sqlCommand.Parameters.Add(AddParameter("@ProcessCardDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForProcessCardDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
