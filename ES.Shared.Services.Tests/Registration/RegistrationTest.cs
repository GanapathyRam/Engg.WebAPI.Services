using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ES.Shared.Services.Controllers.Registration;
using ES.Services.DataTransferObjects.Request.Registration;
using ES.Shared.Services.Tests.Configuration;

namespace ES.Shared.Services.Tests
{
    [TestClass]
    public class RegistrationTest : BaseTest
    {
        [TestMethod]
        public void RegistrationTestPositive()
        {
            // Arrange
            const string UserGuid = "78ea60de-6f95-4d45-a0a6-aaca228debd2";
            var registrationRequestDto = new RegisterUserRequestDto
            {
                UserGuid = Guid.Parse(UserGuid),
                Email = "rakesh@ES.com",
                FirstName = "user20",
                LastName = "user20",
                Password = "ES@123",
                PhoneNumber = "9012345678",
                UserName = "rakeshre",
                UserType = 2

                // TempPassword = "ESTUst12!@"
            };

            // Act
            var registrationProvider = Factory.RegistrationBusinessProvider();
            var responseDto = registrationProvider.RegisterUser(registrationRequestDto);

            // Assert
            Assert.AreEqual(responseDto.ServiceResponseStatus, 1);
        }
    }
}
