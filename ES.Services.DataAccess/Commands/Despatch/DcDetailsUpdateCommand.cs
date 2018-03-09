using System;
using System.Collections.Generic;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class DcDetailsUpdateCommand : SsDbCommand
    {
        public void Execute(string DcNumber, string WoNumber, decimal DcSerial, decimal Quantity, int WoSerail)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateDcDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, WoNumber));
                sqlCommand.Parameters.Add(AddParameter("@DcSerial", SsDbType.Decimal, ParameterDirection.Input, DcSerial));
                sqlCommand.Parameters.Add(AddParameter("@Quantity", SsDbType.Decimal, ParameterDirection.Input, Quantity));
                sqlCommand.Parameters.Add(AddParameter("@WoSerial", SsDbType.Int, ParameterDirection.Input, WoSerail));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
