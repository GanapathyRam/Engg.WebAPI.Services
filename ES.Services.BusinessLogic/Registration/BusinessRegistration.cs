using ES.Services.BusinessLogic.Interface.Registration;
using System;
using ES.Services.DataTransferObjects.Request.Registration;
using ES.Services.DataTransferObjects.Response.Registration;
using ES.Services.DataAccess.Interface.Registration;
using SS.Framework.Exceptions;
using ES.Services.DataAccess.Model.CommandModel.Registration;

namespace ES.Services.BusinessLogic.Registration
{
    public class BusinessRegistration : IBusinessRegistration
    {
        private readonly IRegistrationRepository registrationRepository;

        public BusinessRegistration(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public RegisterUserResponseDto RegisterUser(RegisterUserRequestDto registerUserRequestDto)
        {
            ValidateRegisterUserRequestDto(registerUserRequestDto);

            var registerUserResponseDto = new RegisterUserResponseDto();

            var userMapCM = new UserInfoCommandModel
            {
                CreatedBy = registerUserRequestDto.UserGuid,
                CreatedDateTime = DateTime.UtcNow,
                Email = registerUserRequestDto.Email,
                FirstName = registerUserRequestDto.FirstName,
                LastName = registerUserRequestDto.LastName,
                Password = registerUserRequestDto.Password, //TODO: change it
                PasswordSalt = "", //TODO: change it
                PhoneNumber = registerUserRequestDto.PhoneNumber,
                UpdatedBy = registerUserRequestDto.UserGuid,
                UpdatedDateTime = DateTime.UtcNow,
                UserGuid = registerUserRequestDto.UserGuid,
                UserName = registerUserRequestDto.UserName,
                UserType = registerUserRequestDto.UserType
            };

            var response = registrationRepository.InsertUserInfo(userMapCM);

            return new RegisterUserResponseDto { UserId = response.UserId};
        }
        private static void ValidateRegisterUserRequestDto(RegisterUserRequestDto registerUserRequestDto)
        {
            if (registerUserRequestDto == null || string.IsNullOrWhiteSpace(registerUserRequestDto.Email)
               || registerUserRequestDto.UserGuid == Guid.Empty
               || string.IsNullOrEmpty(registerUserRequestDto.FirstName)
               || string.IsNullOrEmpty(registerUserRequestDto.LastName))
            {
                throw new SSException(
                    ExceptionAttributes.ExceptionCodes.InvalidInput,
                    ExceptionAttributes.ExceptionMessages.InvalidInput);
            }
        }
    }
}
