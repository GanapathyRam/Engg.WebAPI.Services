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
    public class UpdateJobCardMaintanceUpdateCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForInvoiceDetails, UpdateJobCardMaintanceCM updateJobCardMaintanceCM)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateJobCardMaintance]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, updateJobCardMaintanceCM.PartCode));
                sqlCommand.Parameters.Add(AddParameter("@SequeneNumber", SsDbType.Decimal, ParameterDirection.Input, updateJobCardMaintanceCM.SequenceNumber));
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.VarChar, ParameterDirection.Input, updateJobCardMaintanceCM.SerialNo));
                sqlCommand.Parameters.Add(AddParameter("@ActualSettingTime", SsDbType.Decimal, ParameterDirection.Input, updateJobCardMaintanceCM.ActualSettingTime));
                sqlCommand.Parameters.Add(AddParameter("@ActualRunningTime", SsDbType.Decimal, ParameterDirection.Input, updateJobCardMaintanceCM.ActualRunningTime));
                sqlCommand.Parameters.Add(AddParameter("@OperationDate", SsDbType.DateTime, ParameterDirection.Input, updateJobCardMaintanceCM.OperationDate));
                sqlCommand.Parameters.Add(AddParameter("@Shift", SsDbType.VarChar, ParameterDirection.Input, updateJobCardMaintanceCM.Shift));
                sqlCommand.Parameters.Add(AddParameter("@EmployeeCode", SsDbType.BigInt, ParameterDirection.Input, updateJobCardMaintanceCM.EmployeeCode));
                sqlCommand.Parameters.Add(AddParameter("@UpdateJobCardDetails", SsDbType.Structured, ParameterDirection.Input, dataTableForInvoiceDetails));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
