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
    public class ScDeleteCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForScDetails, string ScNumber, string WoNumber, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteScMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeleteWODetails", SsDbType.Structured, ParameterDirection.Input, dataTableForScDetails));
                sqlCommand.Parameters.Add(AddParameter("@SCDcNumber", SsDbType.VarChar, ParameterDirection.Input, ScNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, WoNumber));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
