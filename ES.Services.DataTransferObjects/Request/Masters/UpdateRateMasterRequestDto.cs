using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class UpdateRateMasterRequestDto
    {
        public decimal ItemCode { get; set; }
        public decimal VendorCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
    }
}
