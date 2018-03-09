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
    public class AuthenticationController : ApiController, IReportAuthentication
    {
        private readonly IReportAuthentication reportAuthentication;

        public AuthenticationController()
        {
            reportAuthentication = ObjectFactory.GetInstance<IReportAuthentication>();
        }

        [HttpPost]
        public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
        {
            AuthenticationResponseDto authenticationResponseDto;

            try
            {
                authenticationResponseDto = reportAuthentication.Authenticate(authenticationRequestDto);
                if (string.IsNullOrEmpty(authenticationResponseDto.UserName))
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
    }
}
