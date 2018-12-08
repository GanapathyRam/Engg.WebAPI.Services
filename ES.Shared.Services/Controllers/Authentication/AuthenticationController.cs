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
        public RoleResponseDto GetRoles()
        {
            RoleResponseDto roleResponseDto;
            try
            {
                roleResponseDto = reportAuthentication.GetRoles();
                roleResponseDto.ServiceResponseStatus = 1;
                
            }
            catch (SSException exception)
            {
                roleResponseDto = new RoleResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                roleResponseDto = new RoleResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return roleResponseDto;
        }


        [HttpPost]
        public UsersResponseDto GetUsers()
        {
            UsersResponseDto usersResponseDto;
            try
            {
                usersResponseDto = reportAuthentication.GetUsers();
                usersResponseDto.ServiceResponseStatus = 1;

            }
            catch (SSException exception)
            {
                usersResponseDto = new UsersResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = exception.Message,
                    ErrorCode = exception.ExceptionCode
                };
            }
            catch (Exception exception)
            {
                usersResponseDto = new UsersResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }

            return usersResponseDto;
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

        public UserActivateResponseDto UpdateUserActive(UserActivateRequestDto userActivateRequestDto)
        {
            UserActivateResponseDto userActivateResponseDto;

            try
            {
                userActivateResponseDto = businessAuthentication.UpdateUserActive(userActivateRequestDto);
                userActivateResponseDto.ServiceResponseStatus = 1;
            }
            catch (SSException applicationException)
            {
                userActivateResponseDto = new UserActivateResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                userActivateResponseDto = new UserActivateResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }


            return userActivateResponseDto;
        }

        public UserActivateResponseDto UpdateUserPassword(UserPasswordRequestDto userPasswordRequestDto)
        {
            UserActivateResponseDto userActivateResponseDto =new UserActivateResponseDto();

            try
            {
                AuthenticationRequestDto authenticationRequestDto = new AuthenticationRequestDto {
                    UserName= userPasswordRequestDto.UserName,
                    UserPassword= userPasswordRequestDto.Password
                };
                var authenticationResponseDto = reportAuthentication.Authenticate(authenticationRequestDto);
                if (string.IsNullOrEmpty(authenticationResponseDto.LoginName))
                {
                    userActivateResponseDto.ServiceResponseStatus = 0;
                    userActivateResponseDto.ErrorMessage = "Old Password is invalid";
                }
                else
                {
                    userActivateResponseDto = businessAuthentication.UpdateUserPassword(userPasswordRequestDto);
                    userActivateResponseDto.ServiceResponseStatus = 1;
                }
                
            }
            catch (SSException applicationException)
            {
                userActivateResponseDto = new UserActivateResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorMessage = applicationException.Message,
                    ErrorCode = applicationException.ExceptionCode
                };

            }
            catch (Exception exception)
            {
                userActivateResponseDto = new UserActivateResponseDto
                {
                    ServiceResponseStatus = 0,
                    ErrorCode = ExceptionAttributes.ExceptionCodes.InternalServerError,
                    ErrorMessage = exception.Message
                };
            }


            return userActivateResponseDto;
        }
    }
}
