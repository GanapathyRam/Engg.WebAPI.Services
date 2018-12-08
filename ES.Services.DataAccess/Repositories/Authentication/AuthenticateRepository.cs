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

        public RegistrationQM UserRegistration(RegistrationCM registrationCM)
        {
            RegistrationQM registrationQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var registrationInsertCommand = new RegistrationInsertCommand { Connection = connection };
                registrationQM = registrationInsertCommand.Execute(registrationCM);
            }
            return registrationQM;
        }

        public RolesQM GetRoles()
        {
            RolesQM rolesQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var rolesInsertCommand = new RolesSelectCommand { Connection = connection };
                rolesQM = rolesInsertCommand.Execute();
            }
            return rolesQM;
        }

        public UsersQM GetUsers()
        {
            UsersQM usersQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var rolesInsertCommand = new UsersSelectCommand { Connection = connection };
                usersQM = rolesInsertCommand.Execute();
            }
            return usersQM;
        }

        public UserActivateQM UpdateUserActive(UserActivateCM userActivateCM)
        {
            UserActivateQM userActivateQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var registrationInsertCommand = new UserActivateCommand { Connection = connection };
                userActivateQM = registrationInsertCommand.Execute(userActivateCM);
            }
            return userActivateQM;
        }

        public UserActivateQM UpdateUserPassword(UserPasswordCM userPasswordCM)
        {
            UserActivateQM userActivateQM;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var registrationInsertCommand = new UserPasswordCommand { Connection = connection };
                userActivateQM = registrationInsertCommand.Execute(userPasswordCM);
            }
            return userActivateQM;
        }
    }
}
