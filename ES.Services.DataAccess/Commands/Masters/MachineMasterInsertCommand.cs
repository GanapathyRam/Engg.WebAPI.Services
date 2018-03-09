using ES.Services.DataAccess.Model.CommandModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class MachineMasterInsertCommand : SsDbCommand
    {
        public int Execute(AddMachineMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddMachineMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@MachineName", SsDbType.VarChar, ParameterDirection.Input, model.MachineName));
                sqlCommand.Parameters.Add(AddParameter("@AddedDate", SsDbType.DateTime, ParameterDirection.Input, model.AddedDate));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@MachineCode", SsDbType.Decimal, ParameterDirection.Output, default(int)));
                sqlCommand.ExecuteNonQuery();

                return Convert.ToInt32(sqlCommand.Parameters["@MachineCode"].Value);
            }

        }
    }
}
