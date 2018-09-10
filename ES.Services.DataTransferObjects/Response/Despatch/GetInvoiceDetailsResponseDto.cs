using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetInvoiceDetailsResponseDto : BaseResponse
    {
        public IEnumerable<SavedInvoiceDetails> GetSavedInvoiceDetailsList { get; set; }
    }

    public class SavedInvoiceDetails
    {
        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public decimal PartCode { get; set; }

        public string PartDescription { get; set; }

        public decimal Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal Rate { get; set; }

        public decimal Value { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingNumberRevision { get; set; }
        public string ItemCode { get; set; }
        public string MaterialDescription { get; set; }
        public string HeatNo { get; set; }
        public string PONumber { get; set; }
        public string SerialNos { get; set; }
        public string WDCNumber { get; set; }

        public string DrawingUnit { get; set; }

    }
}
