using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Despatch
{
    public class DeleteInvoiceCM
    {
        public IList<DeleteInvoiceCMModel> DeleteInvoiceCMModelList { get; set; }

        public string DcNumber { get; set; }

        public string InvoiceNumber { get; set; }
    }

    public class DeleteInvoiceCMModel
    {
        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal DcSerial { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
