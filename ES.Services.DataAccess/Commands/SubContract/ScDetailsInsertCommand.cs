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
    public class ScDetailsInsertCommand : SsDbCommand
    {
        public void Execute(string ScNumber, string WoNumber, decimal WoSerial, decimal PartCode)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddScDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@ScDCNumber", SsDbType.VarChar, ParameterDirection.Input, ScNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, WoNumber));
                sqlCommand.Parameters.Add(AddParameter("@PartCode ", SsDbType.Decimal, ParameterDirection.Input, PartCode));
                sqlCommand.Parameters.Add(AddParameter("@WoSerial", SsDbType.Decimal, ParameterDirection.Input, WoSerial));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
