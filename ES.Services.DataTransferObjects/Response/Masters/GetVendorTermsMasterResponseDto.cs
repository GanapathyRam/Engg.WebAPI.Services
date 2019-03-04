using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
   public class GetVendorTermsMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<VendorTermsMaster> VendorTermsMasterList { get; set; }
    }
    public class VendorTermsMaster
    {
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public decimal CGSTPercent { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal IGSTPercent { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryTerms { get; set; }
        public string Documents { get; set; }
        public string Transport { get; set; }
        public string Remarks { get; set; }
    }
}
