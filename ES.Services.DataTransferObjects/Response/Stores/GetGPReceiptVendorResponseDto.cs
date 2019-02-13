using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GetGPReceiptVendorResponseDto:BaseResponse
    {
        public IEnumerable<GPReceiptVendorResponse> gpReceiptVendorList { get; set; }
    }
    public class GPReceiptVendorResponse
    {
        public Int64 VendorCode { get; set; }

        public string VendorShortName { get; set; }

        public string VendorName { get; set; }
    }
}
