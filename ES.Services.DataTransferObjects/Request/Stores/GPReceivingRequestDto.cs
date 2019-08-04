using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class GPReceivingRequestDto
    {
        public string GPReceiptNumber { get; set; }

        public DateTime GPReceiptDate { get; set; }

        public Int64 VendorCode { get; set; }

        public string DocumentID { get; set; }

        public DateTime DocumentDate { get; set; }

        public string Remarks { get; set; }

        public List<GPReceivingDetails> GPReceivingDetails { get; set; }
    }

    public class GPReceivingDetails
    {
        public string GPReceiptNumber { get; set; }

        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public decimal ReceiptQuantity { get; set; }
    }
}
