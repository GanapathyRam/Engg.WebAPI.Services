using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetVendorMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<VendorMasterModel> VendorMasterList { get; set; }
    }
}
