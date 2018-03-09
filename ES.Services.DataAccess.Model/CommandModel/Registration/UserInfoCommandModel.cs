using System;

namespace ES.Services.DataAccess.Model.CommandModel.Registration
{
    public class UserInfoCommandModel
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public short UserType { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }

    }
}
