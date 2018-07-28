using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.SubContract
{
    public class GetScReceivingDetailsRequestDto
    {
        public Int64 VendorCode { get; set; }

        public string DcNumber { get; set; }
    }
}
