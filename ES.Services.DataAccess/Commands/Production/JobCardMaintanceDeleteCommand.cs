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
    class JobCardMaintanceDeleteCommand : SsDbCommand
    {
        public void Execute(string serialNo, decimal partCode, decimal sequenceNumber)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteJobCardDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@SerialNo", SsDbType.VarChar, ParameterDirection.Input, serialNo));
                sqlCommand.Parameters.Add(AddParameter("@PartCode", SsDbType.Decimal, ParameterDirection.Input, partCode));
                sqlCommand.Parameters.Add(AddParameter("@SequeneNumber", SsDbType.Decimal, ParameterDirection.Input, sequenceNumber));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
