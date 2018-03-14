using ES.Services.BusinessLogic.Interface.Authentication;
using ES.Services.DataTransferObjects.Request.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;
using ES.Services.ReportLogic.Interface.Authentication;
using SS.Framework.Exceptions;
using SS.Framework.Services;
using StructureMap;
using System;
using System.Web.Http;

namespace ES.Shared.Services.Controllers.Authentication
{
    public class AuthenticationController : ApiController, IReportAuthentication, IBusinessAuthentication
    {
        private readonly IReportAuthentication reportAuthentication;
        private readonly IBusinessAuthentication businessAuthentication;

        public AuthenticationController()
        {
            this.reportAuthentication = ObjectFactory.GetInstance<IReportAuthentication>();
            this.businessAuthentication = ObjectFactory.GetInstance<IBusinessAuthentication>();
        }

        [HttpPost]
        public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
        {
            AuthenticationResponseDto authenticationResponseDto;

            try
            {
                authenticationResponseDto = reportAuthentication.Authenticate(authenticationRequestDto);
                if (string.IsNullOrEmpty(authenticationResponseDto.LoginName))
                {
                    authenticationResponseDto.ServiceResponseStatus = 0;
                }
                else {
                    authenticationResponseDto.ServiceResponseStatus = 1;
                }
            }
            catch (SSException exception)
            {
                authenticationResponseDto = new AuthenticationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                authenticationResponseDto = new AuthenticationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return authenticationResponseDto;
        }

        [HttpPost]
        public RegistrationResponseDto RegisterUser(RegistrationRequestDto registrationRequestDto)
        {
            RegistrationResponseDto registrationResponseDto;

            try
            {
                registrationResponseDto = businessAuthentication.RegisterUser(registrationRequestDto);
                registrationResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                registrationResponseDto = new RegistrationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                registrationResponseDto = new RegistrationResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }


            return registrationResponseDto;
        }
    }
}
