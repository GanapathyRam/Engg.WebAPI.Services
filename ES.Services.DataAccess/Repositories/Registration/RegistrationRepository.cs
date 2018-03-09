using ES.Services.DataAccess.Commands.Registration;
using ES.Services.DataAccess.Interface.Registration;
using ES.Services.DataAccess.Model.CommandModel.Registration;
using ES.Services.DataAccess.Model.QueryModel.Registration;

namespace ES.Services.DataAccess.Repositories.Registration
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public UserInfoQueryModel InsertUserInfo(UserInfoCommandModel userMapCommandModel)
        {
            long userId;
            using (var connection = new DbConnectionProvider().CreateConnection())
            {
                connection.Open();

                var userRegistrationCommand = new UserRegistrationInsertCommand { Connection = connection };
                userId = userRegistrationCommand.Execute(userMapCommandModel);
            }

            return new UserInfoQueryModel { UserId = userId};
        }
    }
}
