using ES.Services.DataAccess.Commands.Authentication;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Model.CommandModel.Authentication;
using ES.Services.DataAccess.Model.QueryModel.Authentication;

namespace ES.Services.DataAccess.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public CustomUserInformationQueryModel GetUserInformation(CustomUserInformationCommandModel customUserInformationCM)
        {
            CustomUserInformationQueryModel userInformationQueryModel;

            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var userInformationSelectCommand = new CustomUserInformationSelectCommand { Connection = connection };
                userInformationQueryModel = userInformationSelectCommand.Execute(customUserInformationCM.UserName, customUserInformationCM.Password);
            }

            return userInformationQueryModel;
        }
    }
}
