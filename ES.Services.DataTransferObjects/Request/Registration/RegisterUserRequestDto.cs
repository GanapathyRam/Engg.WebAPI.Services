using System;

namespace ES.Services.DataTransferObjects.Request.Registration
{
    public class RegisterUserRequestDto
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public short UserType { get; set; }

        public string Password { get; set; }
    }
}