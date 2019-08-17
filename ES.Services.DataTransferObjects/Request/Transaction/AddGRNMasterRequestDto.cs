using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class AddGRNMasterRequestDto
    {
        public string GRNNumber { get; set; }

        public DateTime GRNDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public Int64 VendorCode { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Remarks { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public List<AddGRNDetails> GetAddGRNDetailsList { get; set; }
    }

    public class AddGRNDetails
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}