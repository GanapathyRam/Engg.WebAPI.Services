using System;

namespace ES.Services.DataAccess.Model.QueryModel.Authentication
{
    public class CustomUserInformationQueryModel
    {
        public Guid UserGuid { get; set; }

        public string UserPassword { get; set; }

        public string PasswordSalt { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public short UserType { get; set; }

    }
}
