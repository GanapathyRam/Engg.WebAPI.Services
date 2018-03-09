
using System;

namespace ES.Services.DataTransferObjects.Response.Authentication
{
    public class AuthenticationResponseDto : BaseResponse
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public short UserType { get; set; }
    }
}
