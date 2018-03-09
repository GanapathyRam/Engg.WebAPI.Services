using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Despatch
{
    public class DcDetailsInsertCommand : SsDbCommand
    {
        public void Execute(string DcNumber, string WoNumber, decimal DcSerial, Int64 PartCode, decimal Quantity, string Remarks, bool InvoicedTag, int WoSerail)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddDcDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DcNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, WoNumber));
                sqlCommand.Parameters.Add(AddParameter("@DcSerial", SsDbType.Decimal, ParameterDirection.Input, DcSerial));
                sqlCommand.Parameters.Add(AddParameter("@PartCode ", SsDbType.BigInt, ParameterDirection.Input, PartCode));
                sqlCommand.Parameters.Add(AddParameter("@Quantity", SsDbType.Decimal, ParameterDirection.Input, Quantity));
                sqlCommand.Parameters.Add(AddParameter("@Remarks", SsDbType.VarChar, ParameterDirection.Input, Remarks));
                sqlCommand.Parameters.Add(AddParameter("@InvoicedTag", SsDbType.Bit, ParameterDirection.Input, InvoicedTag));
                sqlCommand.Parameters.Add(AddParameter("@WoSerial", SsDbType.Int, ParameterDirection.Input, WoSerail));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}
