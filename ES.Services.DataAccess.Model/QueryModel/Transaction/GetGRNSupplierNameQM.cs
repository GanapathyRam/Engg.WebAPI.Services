using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Transaction
{
    public class GetGRNSupplierNameQM
    {
        public IEnumerable<GetGRNSupplierNameModel> GetGRNSupplierNameModelList { get; set; }
    }

    public class GetGRNSupplierNameModel
    {
        public Int64 VendorCode { get; set; }


        public string VendorName { get; set; }
    }
}
