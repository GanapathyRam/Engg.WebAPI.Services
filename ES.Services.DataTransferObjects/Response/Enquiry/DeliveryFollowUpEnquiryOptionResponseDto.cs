using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Enquiry
{
    public class DeliveryFollowUpEnquiryOptionResponseDto : BaseResponse
    {
        public IList<DeliveryFollowUpEnquiryOptionResponse> GetDeliveryFollowUpEnquiryOptionResponse { get; set; }
    }

    public class DeliveryFollowUpEnquiryOptionResponse
    {
        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public string SerialNo { get; set; }

        public string HeatNo { get; set; }

        public string DeliveryDate { get; set; }

        public bool DC { get; set; }
    }
}
