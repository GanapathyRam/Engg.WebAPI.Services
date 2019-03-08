using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
   public class DeleteRateMasterRequestDto
    {
        public decimal ItemCode { get; set; }
        public decimal VendorCode { get; set; }
    }
}
