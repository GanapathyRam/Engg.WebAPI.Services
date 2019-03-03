using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateGroupMasterRequestDto
    {
        public decimal GroupCode { get; set; }

        public string GroupDescription { get; set; }
    }
}
