using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class UpdatePORequestDto
    {
        public string PONumber { get; set; }

        public string POTypeCode { get; set; }

        public string VendorCode { get; set; }

        public DateTime PODate { get; set; }

        public decimal POAmendNumber { get; set; }

        public DateTime POAmendDate { get; set; }

        public string Reference { get; set; }

        public DateTime ReferenceDate { get; set; }

        public decimal CGSTPercent { get; set; }

        public decimal SGSTPercent { get; set; }

        public decimal IGSTPercent { get; set; }

        public string PaymentTerms { get; set; }

        public string DeliveryTerms { get; set; }

        public string Documents { get; set; }

        public string Transport { get; set; }

        public string Remarks { get; set; }

        public List<UpdatePORequestDetails> UpdatePORequestDetails { get; set; }
    }

    public class UpdatePORequestDetails
    {
        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public decimal POAmendNumber { get; set; }

        public string ItemCode { get; set; }

        public string UOMCode { get; set; }

        public decimal POQuantity { get; set; }

        public decimal PORate { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal ItemRate { get; set; }

        public decimal Amount { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal ShortCloseQuantity { get; set; }

        public bool IsNew { get; set; }
    }
}
