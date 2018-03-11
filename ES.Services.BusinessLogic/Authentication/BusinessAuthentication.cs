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
            RegistrationResponseDto registrationResponseDto=new RegistrationResponseDto();
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
                IsActive =true,
                FirstName = registrationRequestDto.FirstName,
                LastName = registrationRequestDto.LastName,

            };

            var response = authenticationRepository.UserRegistration(cModel);
            registrationResponseDto.RegisteredUserId = response.RegisteredUserId;
            return registrationResponseDto;
        }
    }
}
