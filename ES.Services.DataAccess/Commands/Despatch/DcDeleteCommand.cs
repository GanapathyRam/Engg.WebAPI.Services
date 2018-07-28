using ES.Services.DataAccess.Model.CommandModel.Despatch;
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
    public class DcDeleteCommand : SsDbCommand
    {
        public void Execute(DataTable dataTableForDcDetails, string DcNumber, string WoNumber, int IsDeleteFrom)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspDeleteDcMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@DeleteWODetails", SsDbType.Structured, ParameterDirection.Input, dataTableForDcDetails));
                sqlCommand.Parameters.Add(AddParameter("@DCNumber", SsDbType.VarChar, ParameterDirection.Input, DcNumber));
                sqlCommand.Parameters.Add(AddParameter("@WoNumber", SsDbType.VarChar, ParameterDirection.Input, WoNumber));
                sqlCommand.Parameters.Add(AddParameter("@IsDeleteFrom", SsDbType.Int, ParameterDirection.Input, IsDeleteFrom));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
