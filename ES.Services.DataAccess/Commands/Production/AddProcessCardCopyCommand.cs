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
    public class AddProcessCardCopyCommand : SsDbCommand
    {
        public void Execute(decimal FromPartCode, decimal ToPartCode)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddCopyProcessCardDetails]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@FromPartCode", SsDbType.Decimal, ParameterDirection.Input, FromPartCode));
                sqlCommand.Parameters.Add(AddParameter("@ToPartCode", SsDbType.Decimal, ParameterDirection.Input, ToPartCode));

                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
