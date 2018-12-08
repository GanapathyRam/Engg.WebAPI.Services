using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Authentication
{
    public class RoleResponseDto : BaseResponse
    {
        public IEnumerable<RoleResponse> roleList { get; set; }
    }

    public class RoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
