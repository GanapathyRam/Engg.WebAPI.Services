using ES.Services.DataAccess.Model.CommandModel.Masters;
using ES.Services.DataAccess.Model.QueryModel.Masters;
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
    public class GroupMasterUpdateCommand : SsDbCommand
    {
        public UpdateGroupMasterQM Execute(UpdateGroupMasterCM model)
        {
            var response = new UpdateGroupMasterQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateGroupMaster]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(AddParameter("@GroupDescription", SsDbType.VarChar, ParameterDirection.Input, model.GroupDescription));

                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.VarChar, ParameterDirection.Input, model.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.UtcNow));

                sqlCommand.Parameters.Add(AddParameter("@GroupCode", SsDbType.Decimal, ParameterDirection.InputOutput, model.GroupCode));
                sqlCommand.ExecuteNonQuery();
                response.GroupCode = Convert.ToInt32(sqlCommand.Parameters["@GroupCode"].Value);
                return response;
            }

        }

    }
}
