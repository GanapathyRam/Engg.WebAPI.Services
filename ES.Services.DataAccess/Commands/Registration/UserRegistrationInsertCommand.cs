using ES.Services.DataAccess.Model.CommandModel.Registration;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Registration
{
    public class UserRegistrationInsertCommand : SsDbCommand
    {
        public long Execute(UserInfoCommandModel userMapCM)
        {
            long userId;
            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspAddUserInfo]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@UserGUID", SsDbType.UniqueIdentifier, ParameterDirection.Input, userMapCM.UserGuid));
                sqlCommand.Parameters.Add(AddParameter("@UserFirstName", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.FirstName));
                sqlCommand.Parameters.Add(AddParameter("@UserLastName", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.LastName));
                sqlCommand.Parameters.Add(AddParameter("@Email", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.Email));
                sqlCommand.Parameters.Add(AddParameter("@PhoneNumber", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.PhoneNumber));
                sqlCommand.Parameters.Add(AddParameter("@UserName", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.UserName));
                sqlCommand.Parameters.Add(AddParameter("@UserType", SsDbType.SmallInt, ParameterDirection.Input, userMapCM.UserType));
                sqlCommand.Parameters.Add(AddParameter("@UserPassword", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.Password));
                sqlCommand.Parameters.Add(AddParameter("@PasswordSalt", SsDbType.NVarChar, ParameterDirection.Input, userMapCM.PasswordSalt));
                sqlCommand.Parameters.Add(AddParameter("@CreatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, userMapCM.CreatedBy));
                sqlCommand.Parameters.Add(AddParameter("@CreatedDateTime", SsDbType.DateTime, ParameterDirection.Input, userMapCM.CreatedDateTime));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedBy", SsDbType.UniqueIdentifier, ParameterDirection.Input, userMapCM.UpdatedBy));
                sqlCommand.Parameters.Add(AddParameter("@UpdatedDateTime", SsDbType.DateTime, ParameterDirection.Input, userMapCM.UpdatedDateTime));
                sqlCommand.Parameters.Add(AddParameter("@UserID", SsDbType.BigInt, ParameterDirection.Output, default(long)));

                sqlCommand.ExecuteNonQuery();

                userId = Convert.ToInt64(sqlCommand.Parameters["@UserID"].Value);
            }

            return userId;
        }
    }
}
