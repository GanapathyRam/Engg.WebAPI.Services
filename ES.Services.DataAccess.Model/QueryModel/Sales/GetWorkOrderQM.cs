using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Sales
{
    public class GetWorkOrderQM
    {
        public string WorkOrderType { get; set; }
        public string WorkOrderNumber { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal MaxSerial { get; set; }
        public string VendorName { get; set; }

        public IEnumerable<GetWorkOrderModel> getWorkOrderModel { get; set; }
    }
}
