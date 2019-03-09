using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class GPTypeMasterRequestDto
    {
        public string GPType { get; set; }
        public string GPNumber { get; set; }
        public DateTime GPDate { get; set; }
        public Int64 VendorCode { get; set; }
        public Int64 RequestedBy { get; set; }
        public string Remarks { get; set; }
    }
    public class GPTypeSerialRequest
    {
     public Int64 GPSerialNo { get; set; }
    public string Description { get; set; }
    public decimal Units { get; set; }
    public decimal SentQuantity { get; set; }
    public decimal ReceivedQuantity { get; set; }
}
}
