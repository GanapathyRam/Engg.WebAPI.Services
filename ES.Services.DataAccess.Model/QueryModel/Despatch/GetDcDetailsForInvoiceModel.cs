using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetDcDetailsForInvoiceModel
    {
        public string DcNumber { get; set; }

        public decimal DcSerail { get; set; }

        public decimal PartCode { get; set; }

        public decimal Quantity { get; set; }

        public string Remarks { get; set; }

        public bool Invoiced { get; set; }

        public string WoNumber { get; set; }

        public int WoSerial { get; set; }

        public string PartDescription { get; set; }
    }
}
