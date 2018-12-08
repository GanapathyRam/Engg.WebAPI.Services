using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Authentication
{
  public class RegistrationCM
    {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }       
        public string PasswordSalt { get; set; }
        public int? LoginFailureCount { get; set; }
        public bool? IsFirstLogin { get; set; }
        public DateTime? FirstSuccessfulLoginDateTime { get; set; }
        public DateTime? LastSuccessfulLoginDateTime { get; set; }
        public DateTime? LastLoginFailureDateTime { get; set; }
        public bool? IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }

    }
}
