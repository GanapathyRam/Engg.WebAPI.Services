﻿using ES.ExceptionAttributes;
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

        public AuthenticationResponseDto Authenticate(AuthenticationRequestDto authenticationRequestDto)
        {
            ValidateAuthenticationRequest(authenticationRequestDto);

            var userName = authenticationRequestDto.UserName.Trim().ToLower();
            var password = authenticationRequestDto.UserPassword.ToLower();

            var userInformation = authenticationRepository.GetUserInformation(new CustomUserInformationCommandModel { UserName = userName, Password = password});

            if(password != userInformation.UserPassword)
            {
                return new AuthenticationResponseDto { ErrorMessage = "Invalid credentials" };
            }
            //var byteActualPassword = Convert.FromBase64String(userInformation.UserPassword);
            //var isValidatedPassword = ValidateRecord(
            //                                   ComputeHashedValue(password, userInformation.PasswordSalt),
            //                                   byteActualPassword);

            return GetAuthenticationResponse(userInformation);
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
                UserGuid = userInformation.UserGuid,
                UserFirstName = userInformation.UserFirstName,
                UserLastName = userInformation.UserLastName,
                UserName = userInformation.UserName,
                UserType = userInformation.UserType
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

            if (!userInformation.IsActive)
            {
                throw new SSException(ExceptionCodes.InActiveUser, ExceptionMessages.InActiveUser);
            }
        }
    }
}
