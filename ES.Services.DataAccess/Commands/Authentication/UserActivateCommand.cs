using ES.Services.DataAccess.Model.CommandModel.Authentication;
using ES.Services.DataAccess.Model.QueryModel.Authentication;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Commands.Authentication
{
   public class UserActivateCommand : SsDbCommand
    {
        public UserActivateQM Execute(UserActivateCM userActivateCM)
        {
            UserActivateQM userActivateQM = new UserActivateQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateUserActivate]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(this.AddParameter("@UserId", SsDbType.UniqueIdentifier, ParameterDirection.Input, userActivateCM.UserId));
                sqlCommand.Parameters.Add(this.AddParameter("@isActive", SsDbType.Bit, ParameterDirection.Input, userActivateCM.IsActive));
                sqlCommand.Parameters.Add(this.AddParameter("@RegisteredUserId", SsDbType.UniqueIdentifier, ParameterDirection.Output));

                var reader = sqlCommand.ExecuteNonQuery();
                userActivateQM.RegisteredUserId = (Guid)sqlCommand.Parameters["@RegisteredUserId"].Value;
            }
            return userActivateQM;
        }
    }
}
