using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class GetRateMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<RateMaster> RateMasterList { get; set; }
    }
    public class RateMaster
    {
        public decimal ItemCode { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public string VendorName { get; set; }
        public string ItemDescription { get; set; }
    }
}
