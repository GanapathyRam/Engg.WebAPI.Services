using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Enquiry
{
    public class GetSubContractStockEnquiryResponseDto : BaseResponse
    {
        public IList<GetSubContractStockEnquiryResponse> GetSubContractStockEnquiryResponseList { get; set; }
    }

    public class GetSubContractStockEnquiryResponse
    {
        public string VendorName { get; set; }

        public string SubContractDCNumber { get; set; }
        public DateTime SubContractDate { get; set; }
        public string PartDescription { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingNumberRevision { get; set; }
        public string MaterialDescription { get; set; }
        public string ItemCode { get; set; }
        public string SerialNo { get; set; }
        public string ProcessDescription { get; set; }
    }
}
