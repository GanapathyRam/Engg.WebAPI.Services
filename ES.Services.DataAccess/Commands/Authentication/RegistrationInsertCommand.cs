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
   public class RegistrationInsertCommand : SsDbCommand
    {
        public RegistrationQM Execute(RegistrationCM registrationCM)
        {
            RegistrationQM registrationQM = new RegistrationQM();
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspInsertUserAccountInfo]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(this.AddParameter("@UserId", SsDbType.UniqueIdentifier, ParameterDirection.Input, registrationCM.UserId));
                sqlCommand.Parameters.Add(this.AddParameter("@FirstName", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.FirstName));
                sqlCommand.Parameters.Add(this.AddParameter("@LastName", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.LastName));
                sqlCommand.Parameters.Add(this.AddParameter("@Email", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.Email));
                sqlCommand.Parameters.Add(this.AddParameter("@PhoneNumber", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.PhoneNumber));
                sqlCommand.Parameters.Add(this.AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, DBNull.Value));
                sqlCommand.Parameters.Add(this.AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DBNull.Value));
                sqlCommand.Parameters.Add(this.AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, DBNull.Value));
                sqlCommand.Parameters.Add(this.AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, DBNull.Value));
                sqlCommand.Parameters.Add(this.AddParameter("@LoginName", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.LoginName));
                sqlCommand.Parameters.Add(this.AddParameter("@UserPassword", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.UserPassword));
                sqlCommand.Parameters.Add(this.AddParameter("@PasswordSalt", SsDbType.NVarChar, ParameterDirection.Input, registrationCM.PasswordSalt));
                sqlCommand.Parameters.Add(this.AddParameter("@RoleId", SsDbType.Int, ParameterDirection.Input, registrationCM.RoleId));
                sqlCommand.Parameters.Add(this.AddParameter("@RegisteredUserId", SsDbType.UniqueIdentifier, ParameterDirection.Output));
               
                var reader = sqlCommand.ExecuteNonQuery();
                registrationQM.RegisteredUserId = (Guid)sqlCommand.Parameters["@RegisteredUserId"].Value;
            }
                return registrationQM;
        }
    }
}
