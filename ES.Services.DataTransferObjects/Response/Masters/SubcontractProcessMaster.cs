using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class SubcontractProcessMaster
    {
        public decimal ProcessCode { get; set; }
        public string ProcessDescription { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
