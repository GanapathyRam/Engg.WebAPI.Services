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
                        UserId = Guid.Parse(reader["UserId"].ToString()),
                        UserPassword = reader["UserPassword"].ToString(),
                        PasswordSalt = reader["PasswordSalt"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        LoginName = reader["LoginName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        FullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString()
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
