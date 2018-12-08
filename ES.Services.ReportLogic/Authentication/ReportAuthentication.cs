using AutoMapper;
using ES.ExceptionAttributes;
using ES.Services.DataAccess.Interface.Authentication;
using ES.Services.DataAccess.Model.CommandModel.Authentication;
using ES.Services.DataAccess.Model.QueryModel.Authentication;
using ES.Services.DataTransferObjects.Request.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;
using ES.Services.ReportLogic.Interface.Authentication;
using SS.Common.Crypto.Hash;
using SS.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace ES.Services.ReportLogic.Authentication
{
    public class ReportAuthentication : IReportAuthentication
    {
        private readonly IAuthenticationRepository authenticationRepository;

        public ReportAuthentication(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public RoleResponseDto GetRoles()
        {
            var response = new RoleResponseDto();
            var model = authenticationRepository.GetRoles();
            if (model != null)
            {
                response = RolesMapper((List<RoleResponseModel>)model.roleList, response);
            }

            return response;
        }

        public UsersResponseDto GetUsers()
        {
            var response = new UsersResponseDto();
            var model = authenticationRepository.GetUsers();
            if (model != null)
            {
                response = UsersMapper((List<UserResponseModel>)model.userList, response);
            }

            return response;
        }


        private static RoleResponseDto RolesMapper(List<RoleResponseModel> list, RoleResponseDto roleResponseDto)
        {
            Mapper.CreateMap<RoleResponseModel, RoleResponse>();
            roleResponseDto.roleList =
                Mapper.Map<List<RoleResponseModel>, List<RoleResponse>>(list);

            return roleResponseDto;
        }

        private static UsersResponseDto UsersMapper(List<UserResponseModel> list, UsersResponseDto usersResponseDto)
        {
            Mapper.CreateMap<UserResponseModel, UserResponse>();
            usersResponseDto.userList =
                Mapper.Map<List<UserResponseModel>, List<UserResponse>>(list);

            return usersResponseDto;
        }

        public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
        {
            ValidateAuthenticationRequest(authenticationRequestDto);
            AuthenticationResponseDto auth;

                var userName = authenticationRequestDto.UserName.Trim().ToLower();
            var password = authenticationRequestDto.UserPassword;

            var userInformation = authenticationRepository.GetUserInformation(new CustomUserInformationCommandModel { UserName = userName, Password = password});

            if (userInformation.LoginName != null)
            {
                var hashCode = userInformation.PasswordSalt;
                //Password Hasing Process Call Helper Class Method    
                var encodingPasswordString = Helper.EncodePassword(password, hashCode);
                if(userInformation.UserPassword != encodingPasswordString)
                {
                    return new AuthenticationResponseDto { ErrorMessage = "Invalid credentials" };
                }
            }
            else
            {
                return new AuthenticationResponseDto { ErrorMessage = "Invalid credentials" };
            }
            var responseSend= GetAuthenticationResponse(userInformation);
            responseSend.Token = Helper.GenerateToken(userInformation);
            responseSend.TokenExpiry = Helper.TokenExpirationMins;
            //var byteActualPassword = Convert.FromBase64String(userInformation.UserPassword);
            //var isValidatedPassword = ValidateRecord(
            //                                   ComputeHashedValue(password, userInformation.PasswordSalt),
            //                                   byteActualPassword);

            return responseSend;
        }

        private byte[] ComputeHashedValue(string inputRecord, string storedSalt)
        {
            var bytesInputRecordToHash = Encoding.UTF8.GetBytes(inputRecord);
            var salt = Convert.FromBase64String(storedSalt);
            IHashProvider hashProvider = new PbkDf2Sha256HashProvider(
                ConstantValues.OutputBytesLength,
                ConstantValues.IterationCount);

            var hashedvalue = hashProvider.GetBytes(bytesInputRecordToHash, salt);

            return hashedvalue;
        }

        private bool ValidateRecord(IList<byte> providerRecord, IList<byte> actualRecord)
        {
            var difference = (uint)providerRecord.Count ^ (uint)actualRecord.Count;
            for (var counter = 0; counter < providerRecord.Count && counter < actualRecord.Count; counter++)
            {
                difference |= (uint)(providerRecord[counter] ^ actualRecord[counter]);
            }

            return difference == 0;
        }

        private void ValidateAuthenticationRequest(AuthenticationRequestDto authenticationRequestDto)
        {
            if (authenticationRequestDto == null
                || string.IsNullOrWhiteSpace(authenticationRequestDto.UserName)
                || string.IsNullOrWhiteSpace(authenticationRequestDto.UserPassword))
            {
                throw new SSException(
                    ExceptionCodes.InvalidInput,
                    ExceptionMessages.InvalidInput);
            }
        }

        private AuthenticationResponseDto GetAuthenticationResponse(CustomUserInformationQueryModel userInformation)
        {
            var authenticationResponseDto = new AuthenticationResponseDto
            {
                UserId = userInformation.UserId,
                FirstName = userInformation.FirstName,
                LastName = userInformation.LastName,
                LoginName = userInformation.LoginName,
                Email = userInformation.Email,
                PhoneNumber = userInformation.PhoneNumber,
                RoleId = userInformation.RoleId,
                FullName = userInformation.FirstName + ' ' + userInformation.LastName
            };

            return authenticationResponseDto;
        }

        private static string GenerateToken(string userName)
        {
            const bool IsPersistent = ConstantValues.TicketIsPersistent;
            const string UserData = ConstantValues.TokenUserData;

            var formsAuthenticationTicket =
                new FormsAuthenticationTicket(
                                                ConstantValues.TicketVersion,
                                                userName,
                                                DateTime.Now,
                                                DateTime.Now.AddMinutes(ConstantValues.TicketExpieryTime),
                                                IsPersistent,
                                                UserData,
                                                FormsAuthentication.FormsCookiePath);

            return FormsAuthentication.Encrypt(formsAuthenticationTicket);
        }

        private void ValidateUserInformation(CustomUserInformationQueryModel userInformation, Guid applicationGuid)
        {
            if (userInformation == null)
            {
                throw new SSException(ExceptionCodes.InvalidAuthentication, ExceptionMessages.InvalidAuthentication);
            }
        }
    }
}
