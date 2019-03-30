using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetGRNFromVendorCodeResponseDto : BaseResponse
    {
        public List<GetGRNFromVendorCodeResponse> GetGRNFromVendorCodeResponseList { get; set; }
    }

    public class GetGRNFromVendorCodeResponse
    {
        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public decimal Itemcode { get; set; }

        public string ItemDescription { get; set; }

        public decimal UOMCode { get; set; }

        public string UOMDescription { get; set; }

        public decimal POQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal Balanceqty { get; set; }
    }
}
