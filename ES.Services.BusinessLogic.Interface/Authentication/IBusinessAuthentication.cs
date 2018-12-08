using ES.Services.DataTransferObjects.Request.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.BusinessLogic.Interface.Authentication
{
  public interface IBusinessAuthentication
    {
        RegistrationResponseDto RegisterUser(RegistrationRequestDto registrationRequestDto);
        UserActivateResponseDto UpdateUserActive(UserActivateRequestDto userActivateRequestDto);
        UserActivateResponseDto UpdateUserPassword(UserPasswordRequestDto userPasswordRequestDto);
    }
}
