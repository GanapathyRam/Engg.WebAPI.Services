using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Transaction
{
    public class AddPoMasterCM
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
    }
}
