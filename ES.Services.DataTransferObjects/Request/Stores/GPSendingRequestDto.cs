using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Stores
{
    public class GPSendingRequestDto
    {
        public string GPType { get; set; }

        public string GPNumber { get; set; }

        public Int64 VendorCode { get; set; }

        public DateTime GPDate { get; set; }

        public string RequestedBy { get; set;}

        public string Remarks { get; set; }

        public List<GPSendingDetails> GPSendingDetailsList { get; set; }
    }

    public class GPSendingDetails
    {
        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public string Description { get; set; }

        public decimal Units { get; set; }

        public decimal SentQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }
    }
}
