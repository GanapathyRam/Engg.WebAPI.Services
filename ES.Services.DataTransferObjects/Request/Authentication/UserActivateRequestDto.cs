using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Authentication
{
   public class UserActivateRequestDto
    {
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }
    }
}
