using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetDcMasterModel
    {
        public string WorkOrderType { get; set; }
        public DateTime DcDate { get; set; }
        public string DcNumber { get; set; }
        public Int64 VendorCode { get; set; }
        public string DcType { get; set; }
        public string VehicleNumber { get; set; }
        public bool Billable { get; set; }
        public string VendorName { get; set; }
        public string DcTypeDescription { get; set; }        public string WoTypeDescription { get; set; }
        public bool Invoiced { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string CompanyGST { get; set; }
    }
}
