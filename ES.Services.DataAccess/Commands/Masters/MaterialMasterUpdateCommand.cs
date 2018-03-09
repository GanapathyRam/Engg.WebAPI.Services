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
    public class MaterialMasterUpdateCommand : SsDbCommand
    {
        public void Execute(UpdateMaterialMasterCM model)
        {
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].uspUpdateMaterialMaster";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@MaterialCode", SsDbType.Int, ParameterDirection.Input, Convert.ToInt32(model.MaterialCode)));
                sqlCommand.Parameters.Add(AddParameter("@MaterialDescription", SsDbType.VarChar, ParameterDirection.Input, model.MaterialDescription));
                sqlCommand.Parameters.Add(AddParameter("@MaterialShortDescription", SsDbType.VarChar, ParameterDirection.Input, model.MaterialShortDescription));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, new Guid()));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
