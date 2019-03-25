using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class GPOutsideReturnRequestDto
    {
        public string GPOutsideReturnNumber { get; set; }
        public DateTime GPOutsideReturnDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<GPOutsideReturnDetails> GPOutsideReturnDetailsList { get; set; }
    }

    public class GPOutsideReturnDetails
    {
        public string GPOutsideReturnNumber { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public decimal SentQuantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
