using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Enquiry
{
    public class SalesEnquiryOptionModel
    {
        public string InvoiceNumber { get; set; }

        public string InvoiceDate { get; set; }

        public string VendorName { get; set; }

        public decimal ValueOfGoods { get; set; }

        public decimal SGSTAmount { get; set; }

        public decimal CGSTAmount { get; set; }

        public decimal IGSTAmount { get; set; }

        public decimal FinalTotal { get; set; }
    }
}
