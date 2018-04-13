using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Production
{
    public class AddJobCardGenerationRequestDto
    {
        public List<AddJobCardGenerationRequest> addJobCardGenerationRequestList { get; set; }
    }

    public class AddJobCardGenerationRequest
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string SerialNo { get; set; }
    }
}
