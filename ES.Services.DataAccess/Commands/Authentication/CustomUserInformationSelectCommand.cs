using ES.Services.DataAccess.Model.QueryModel.Authentication;
using SS.Framework.DataAccess;
using SS.Framework.DataAccess.Commands;
using SS.Framework.DataAccess.Helpers;
using System;
using System.Data;

namespace ES.Services.DataAccess.Commands.Authentication
{
    internal class CustomUserInformationSelectCommand : SsDbCommand
    {
        public CustomUserInformationQueryModel Execute(string userName, string password)
        {
            CustomUserInformationQueryModel userInformationQueryModel = null;

            using (var sqlCommand = CreateCommand())
            {
                sqlCommand.Connection = Connection;
                sqlCommand.CommandText = "[dbo].[uspGetUserDetail]";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(AddParameter("@UserName", SsDbType.NVarChar, ParameterDirection.Input, userName));
                sqlCommand.Parameters.Add(AddParameter("@Password", SsDbType.NVarChar, ParameterDirection.Input, password));

                var reader = SsDbCommandHelper.ExecuteReader(sqlCommand);

                if (reader.Read())
                {
                    userInformationQueryModel = new CustomUserInformationQueryModel
                    {
                        UserGuid = Guid.Parse(reader["UserGUID"].ToString()),
                        UserPassword = reader["UserPassword"].ToString(),
                        //PasswordSalt = reader["PasswordSalt"].ToString(),
                        UserFirstName = reader["FirstName"].ToString(),
                        UserLastName = reader["LastName"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        IsActive = (bool)reader["IsActive"],
                        UserType = (short)reader["UserType"],
                    };
                }
                else {
                    userInformationQueryModel = new CustomUserInformationQueryModel();
                }
            }

            return userInformationQueryModel;
        }
    }
}
