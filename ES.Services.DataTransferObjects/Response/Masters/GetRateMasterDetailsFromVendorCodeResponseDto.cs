using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class GetRateMasterDetailsFromVendorCodeResponseDto : BaseResponse
    {
        public decimal Rate { get; set; }

        public decimal Discount { get; set; }
    }
}
