using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GetGPOutsideReturnVendorResponseDto : BaseResponse
    {
        public IEnumerable<GPReturnVendorResponse> gpReturnVendorList { get; set; }
    }
    public class GPReturnVendorResponse
    {
        public Int64 VendorCode { get; set; }

        public string VendorShortName { get; set; }

        public string VendorName { get; set; }
    }
}
