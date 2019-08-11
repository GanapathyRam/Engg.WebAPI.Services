using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Enquiry
{
    public class GetDespatchDetailsEnquiryResponseDto : BaseResponse
    {
        public IList<GetDespatchDetailsEnquiryResponse> GetDespatchDetailsEnquiryResponseList { get; set; }
    }

    public class GetDespatchDetailsEnquiryResponse
    {
        public string VendorName { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceSerial { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Quantity { get; set; }
        public string PartDescription { get; set; }
        public string DrawingNumber { get; set; }

        public string DCNumber { get; set; }
        public decimal DCSerial { get; set; }
        public DateTime DCDate { get; set; }
        public string PONumber { get; set; }
        public string POSerial { get; set; }
        public DateTime PODate { get; set; }
    }
}
