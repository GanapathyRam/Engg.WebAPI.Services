using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ES.Shared.Services.Tests.Configuration;
using ES.Services.DataTransferObjects.Request.Authentication;

namespace ES.Shared.Services.Tests.Authentication
{
    [TestClass]
    public class AuthenticationTest : BaseTest
    {
        [TestMethod]
        public void AuthenticationTestPositive()
        {
            AuthenticationRequestDto authenticationRequest = new AuthenticationRequestDto
            {
                UserName = "rakeshre",
                UserPassword = "ES@123"
            };
            var authenticationProvider = Factory.AuthenticationBusinessProvider();
            var responseDto = authenticationProvider.Authenticate(authenticationRequest);

            Assert.AreEqual(responseDto.ServiceResponseStatus, 1);
        }
    }
}
