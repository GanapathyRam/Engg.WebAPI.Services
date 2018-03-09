using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class AddParameterMasterRequestDto
    {
        public string Description { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
