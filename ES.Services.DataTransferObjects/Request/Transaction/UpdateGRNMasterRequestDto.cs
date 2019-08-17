using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class UpdateGRNMasterRequestDto
    {
        public string GRNNumber { get; set; }

        public DateTime GRNDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public Int64 VendorCode { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public List<UpdateGRNDetails> GetUpdateGRNDetails { get; set; }
    }

    public class UpdateGRNDetails
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public bool IsNew { get; set; }
    }
}
