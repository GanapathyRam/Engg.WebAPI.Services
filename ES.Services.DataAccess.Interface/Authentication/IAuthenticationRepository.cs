using ES.Services.DataAccess.Model.CommandModel.Authentication;
using ES.Services.DataAccess.Model.QueryModel.Authentication;

namespace ES.Services.DataAccess.Interface.Authentication
{
    public interface IAuthenticationRepository
    {
        CustomUserInformationQueryModel GetUserInformation(CustomUserInformationCommandModel customUserInformationCM);
        RegistrationQM UserRegistration(RegistrationCM registrationCM);
        RolesQM GetRoles();
        UsersQM GetUsers();
        UserActivateQM UpdateUserActive(UserActivateCM userActivateCM);
        UserActivateQM UpdateUserPassword(UserPasswordCM userPasswordCM);
    }
}
