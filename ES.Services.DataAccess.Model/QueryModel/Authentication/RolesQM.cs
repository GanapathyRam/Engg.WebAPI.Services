using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Authentication
{
    public class RolesQM
    {
        public IEnumerable<RoleResponseModel> roleList { get; set; }
    }

    public class RoleResponseModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
