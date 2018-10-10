using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Enquiry
{
    public class InvoicedEnquiryOptionResponseDto : BaseResponse
    {
        public IList<InvoicedEnquiryOptionResponse> GetInvoicedEnquiryOptionResponse { get; set; }
    }

    public class InvoicedEnquiryOptionResponse
    {
        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public string MaterialDescription { get; set; }

        public string WONumber { get; set; }

        public string WODate { get; set; }

        public string WOType { get; set; }

        public string WOTypeDescription { get; set; }

        public string SerialNo { get; set; }

        public string HeatNo { get; set; }

        public string DCNumber { get; set; }

        public string DCSerial { get; set; }

        public string PONumber { get; set; }

        public string POSerial { get; set; }
    }
}
