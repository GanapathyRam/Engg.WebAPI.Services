using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetDcSerialForInvoiceSerialQM
    {
        public IEnumerable<GetDcSerialForInvoiceSerialQMModel> GetDcSerialForInvoiceSerialQMList { get; set; }
    }

    public class GetDcSerialForInvoiceSerialQMModel
    {
        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
