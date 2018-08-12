using ES.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Production
{
    public class DeleteJobCardDetailsRequestDto
    {
        public string SerialNo { get; set; }

        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }
    }
}
