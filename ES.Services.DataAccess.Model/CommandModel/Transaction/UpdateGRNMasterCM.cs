using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class UpdateGRNMasterCM
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
    }
}
