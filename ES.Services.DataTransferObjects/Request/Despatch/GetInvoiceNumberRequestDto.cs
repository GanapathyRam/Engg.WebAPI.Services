using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class GetInvoiceNumberRequestDto
    {
        public Int64 VendorCode { get; set; }
        public string WoType { get; set; }
    }
}
