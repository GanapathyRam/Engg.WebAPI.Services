using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class GPOutsideReceiptRequestDto
    {
        public string GPOutsideType { get; set; }
        public string GPOutsideReceiptNumber { get; set; }
        public DateTime GPOutsideReceiptDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string RecievedBy { get; set; }
        public string Remarks { get; set; }
        public List<GPOutsideReceiptDetails> GPOutsideReceiptDetailsList { get; set; }
    }

    public class GPOutsideReceiptDetails
    {
        public string GPOutsideReceiptNumber { get; set; }
        public int GPOutsideSerialNo { get; set; }
        public string Description { get; set; }
        public decimal Units { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal SentQuantity { get; set; }
    }
}
