using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Authentication
{
    public class UserActivateResponseDto : BaseResponse
    {
        public Guid RegisteredUserId { get; set; }
    }
}
