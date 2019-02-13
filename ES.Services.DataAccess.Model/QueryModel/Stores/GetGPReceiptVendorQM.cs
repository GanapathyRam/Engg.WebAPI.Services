using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
   public class GetGPReceiptVendorQM
    {

        public IEnumerable<GPReceiptVendorModel> gpReceiptVendorList { get; set; }
     
    }
    public class GPReceiptVendorModel
    {
           public Int64 VendorCode { get; set; }

        public string VendorShortName { get; set; }

        public string VendorName { get; set; }
    }
}
