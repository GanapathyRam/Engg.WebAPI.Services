using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System.Data;

namespace ES.Services.DataAccess.Commands.Production
{
    public class ProcessCardDeleteCommand : SsDbCommand
    {
        public void Execute(decimal PartCode, decimal SequenceNumber, decimal SerialNo, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteProcessCardMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, PartCode));
                sqlCommand.Parameters.Add(AddParameter("@SequenceNumber", SsDbType.Decimal, ParameterDirection.Input, SequenceNumber));
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.Bit, ParameterDirection.Input, SerialNo));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
