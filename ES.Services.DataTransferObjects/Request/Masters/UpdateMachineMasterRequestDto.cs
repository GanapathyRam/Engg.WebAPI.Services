using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateMachineMasterRequestDto
    {
        public decimal MachineCode { get; set; }

        public string MachineName { get; set; }

        public DateTime AddedDate { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
