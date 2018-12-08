using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Authentication
{
     public class UserActivateCM
    {
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }
    }
}
