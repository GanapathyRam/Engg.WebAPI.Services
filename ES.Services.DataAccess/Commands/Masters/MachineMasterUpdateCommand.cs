using ES.Services.DataAccess.Model.CommandModel.Masters;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Masters
{
    public class MachineMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateMachineMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].uspUpdateMachineMaster";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@MachineCode", SsDbType.Decimal, ParameterDirection.Input, Convert.ToInt32(model.MachineCode)));
                sqlCommand.Parameters.Add(AddParameter("@MachineName", SsDbType.VarChar, ParameterDirection.Input, model.MachineName));
                sqlCommand.Parameters.Add(AddParameter("@AddedDate", SsDbType.DateTime, ParameterDirection.Input, model.AddedDate));

                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

