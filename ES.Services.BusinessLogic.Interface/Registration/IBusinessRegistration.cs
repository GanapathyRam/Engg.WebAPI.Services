using ES.Services.DataTransferObjects.Request.Registration;
using ES.Services.DataTransferObjects.Response.Registration;

namespace ES.Services.BusinessLogic.Interface.Registration
{
    public interface IBusinessRegistration
    {
        RegisterUserResponseDto RegisterUser(RegisterUserRequestDto registerUserRequestDto);
    }
}
