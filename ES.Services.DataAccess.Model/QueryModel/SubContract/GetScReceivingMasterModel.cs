using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.SubContract
{
    public class GetScReceivingMasterModel
    {
        public string ScReceivingDcNumber { get; set; }
        public DateTime ReceiveDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public DateTime VendorDcDate { get; set; }
        public string Vehicle { get; set; }
        public string VendorDCNumber { get; set; }
        public string Remarks { get; set; }
    }
}
