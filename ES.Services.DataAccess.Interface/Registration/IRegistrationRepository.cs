using ES.Services.DataAccess.Model.CommandModel.Registration;
using ES.Services.DataAccess.Model.QueryModel.Registration;

namespace ES.Services.DataAccess.Interface.Registration
{
    public interface IRegistrationRepository
    {
        UserInfoQueryModel InsertUserInfo(UserInfoCommandModel userMapCommandModel);
    }
}
