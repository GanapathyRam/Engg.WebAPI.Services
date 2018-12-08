using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Authentication
{
    public class UserPasswordCM
    {
        public Guid UserId { get; set; }
        public string UserPassword { get; set; }
        public string PasswordSalt { get; set; }
    }
}
