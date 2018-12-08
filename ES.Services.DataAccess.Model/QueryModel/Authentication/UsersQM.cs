using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Authentication
{
   public class UsersQM
    {
        public IEnumerable<UserResponseModel> userList { get; set; }
    }

    public class UserResponseModel
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Boolean IsActive { get; set; }

        public string LoginName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
