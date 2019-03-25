using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GPOutsideReturnVendorQM
    {
        public IEnumerable<GPpReturnVendorModel> gpReturnVendorList { get; set; }
    }
    public class GPpReturnVendorModel
    {
        public Int64 VendorCode { get; set; }

        public string VendorShortName { get; set; }

        public string VendorName { get; set; }
    }
}
