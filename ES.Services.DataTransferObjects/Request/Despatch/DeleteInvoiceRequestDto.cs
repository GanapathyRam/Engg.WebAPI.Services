using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class DeleteInvoiceRequestDto
    {
        public IList<DeleteInvoiceRequestModel> DeleteInvoiceRequestModelList { get; set; }

        public string DcNumber { get; set; }

        public string InvoiceNumber { get; set; }
    }

    public class DeleteInvoiceRequestModel
    {
        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal DcSerial { get; set; }
    }
}
