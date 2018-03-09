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
    public class OperationMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateOperationMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].uspUpdateOperationMaster";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@OperationCode", SsDbType.Decimal, ParameterDirection.Input, Convert.ToInt32(model.OperationCode)));
                sqlCommand.Parameters.Add(AddParameter("@OperationName", SsDbType.VarChar, ParameterDirection.Input, model.OperationName));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
