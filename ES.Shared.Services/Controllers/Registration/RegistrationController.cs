using ES.Services.BusinessLogic.Interface.Registration;
using ES.Services.DataTransferObjects.Request.Registration;
using ES.Services.DataTransferObjects.Response.Registration;
using SS.Framework.Exceptions;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Registration
{
    public class RegistrationController : ApiController, IBusinessRegistration
    {
        private readonly IBusinessRegistration registrationProvider;

        public RegistrationController()
        {
            registrationProvider = ObjectFactory.GetInstance<IBusinessRegistration>();
        }

        public RegisterUserResponseDto RegisterUser(RegisterUserRequestDto registerUserRequestDto)
        {
            RegisterUserResponseDto registerUserResponseDto;

            try
            {
                registerUserResponseDto = registrationProvider.RegisterUser(registerUserRequestDto);
                registerUserResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                registerUserResponseDto = new RegisterUserResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                registerUserResponseDto = new RegisterUserResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return registerUserResponseDto;
        }
    }
}
