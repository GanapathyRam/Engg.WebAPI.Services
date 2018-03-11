using System;

namespace ES.Services.DataAccess.Model.QueryModel.Authentication
{
    public class CustomUserInformationQueryModel
    {
        public Guid UserId { get; set; }

        public string UserPassword { get; set; }

        public string PasswordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LoginName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

}
}
