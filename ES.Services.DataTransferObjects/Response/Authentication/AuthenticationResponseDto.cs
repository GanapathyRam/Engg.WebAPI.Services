
using System;

namespace ES.Services.DataTransferObjects.Response.Authentication
{
    public class AuthenticationResponseDto : BaseResponse
    {
        public Guid UserId { get; set; }

        public string LoginName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Token { get; set; }

        public int TokenExpiry { get; set; }
    }
}
