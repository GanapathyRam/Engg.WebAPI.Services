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
    public class UserPasswordCommand : SsDbCommand
    {
        public UserActivateQM Execute(UserPasswordCM userPasswordCM)
        {
            UserActivateQM userActivateQM = new UserActivateQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspUpdateUserPassword]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(this.AddParameter("@UserId", SsDbType.UniqueIdentifier, ParameterDirection.Input, userPasswordCM.UserId));
                sqlCommand.Parameters.Add(this.AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, userPasswordCM.UserId));
                sqlCommand.Parameters.Add(this.AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DateTime.Now));
                sqlCommand.Parameters.Add(this.AddParameter("@UserPassword", SsDbType.NVarChar, ParameterDirection.Input, userPasswordCM.UserPassword));
                sqlCommand.Parameters.Add(this.AddParameter("@PasswordSalt", SsDbType.NVarChar, ParameterDirection.Input, userPasswordCM.PasswordSalt));
                sqlCommand.Parameters.Add(this.AddParameter("@RegisteredUserId", SsDbType.UniqueIdentifier, ParameterDirection.Output));

                var reader = sqlCommand.ExecuteNonQuery();
                userActivateQM.RegisteredUserId = (Guid)sqlCommand.Parameters["@RegisteredUserId"].Value;
            }
            return userActivateQM;
        }
    }
}
