using ES.Services.BusinessLogic.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.Services.DataTransferObjects.Request.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;
using ES.Services.DataAccess.Model.CommandModel.Authentication;
using ES.Services.DataAccess.Interface.Authentication;
using ES.ExceptionAttributes;

namespace ES.Services.BusinessLogic.Authentication
{
    public class BusinessAuthentication : IBusinessAuthentication
    {
        private readonly IAuthenticationRepository authenticationRepository;
        public BusinessAuthentication(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }
        public RegistrationResponseDto RegisterUser(RegistrationRequestDto registrationRequestDto)
        {
            RegistrationResponseDto registrationResponseDto = new RegistrationResponseDto();
            var keyNew = Helper.GeneratePassword(25);
            var password = Helper.EncodePassword(registrationRequestDto.UserPassword, keyNew);
            var cModel = new RegistrationCM
            {
                UserId = Guid.NewGuid(),
                LoginName = registrationRequestDto.LoginName,
                UserPassword = password,
                Email = registrationRequestDto.Email,
                PhoneNumber = registrationRequestDto.PhoneNumber,
                PasswordSalt = keyNew,
                IsActive = true,
                FirstName = registrationRequestDto.FirstName,
                LastName = registrationRequestDto.LastName,
                RoleId = registrationRequestDto.RoleId
            };

            var response = authenticationRepository.UserRegistration(cModel);
            registrationResponseDto.RegisteredUserId = response.RegisteredUserId;
            return registrationResponseDto;
        }

        public UserActivateResponseDto UpdateUserActive(UserActivateRequestDto userActivateRequestDto)
        {
            UserActivateResponseDto userActivateResponseDto = new UserActivateResponseDto();
            var cModel = new UserActivateCM
            {
                UserId = userActivateRequestDto.UserId,
                IsActive = userActivateRequestDto.IsActive
            };
            var response = authenticationRepository.UpdateUserActive(cModel);

            userActivateResponseDto.RegisteredUserId = response.RegisteredUserId;
            return userActivateResponseDto;
        }

        public UserActivateResponseDto UpdateUserPassword(UserPasswordRequestDto userPasswordRequestDto)
        {
            UserActivateResponseDto userActivateResponseDto = new UserActivateResponseDto();
            var keyNew = Helper.GeneratePassword(25);
            var password = Helper.EncodePassword(userPasswordRequestDto.NewPassword, keyNew);
            var cModel = new UserPasswordCM
            {
                UserId = userPasswordRequestDto.UserId,
                UserPassword = password,
                PasswordSalt = keyNew

            };
            var response = authenticationRepository.UpdateUserPassword(cModel);

            userActivateResponseDto.RegisteredUserId = response.RegisteredUserId;
            return userActivateResponseDto;
        }
    }
}
