using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Despatch
{
    public class InvoiceDetailCM
    {
        public IEnumerable<InvoiceDetailsItems> InvoiceDetailsItems { get; set; }
    }

    public class InvoiceDetailsItems
    {
        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public decimal PartCode { get; set; }

        public decimal Quantity { get; set; }

        public string Remarks { get; set; }

        public decimal Rate { get; set; }

        public decimal Value { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
