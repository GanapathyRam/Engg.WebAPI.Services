using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class GetWOMasterForDcRequestDto
    {
        public Int64 VendorCode { get; set; }

        public string WoType { get; set; }

        public string DcNumber { get; set; }

        public bool Invoiced { get; set; }
    }
}
