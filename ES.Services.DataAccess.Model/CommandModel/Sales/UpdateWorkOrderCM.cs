using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Sales
{
    public class UpdateWorkOrderCM
    {
        public IEnumerable<UpdateWorkOrderMasterItems> UpdateWorkOrderMasterListItems { get; set; }
    }

    public class UpdateWorkOrderMasterItems
    {
        public string WorkOrderNumber { get; set; }
        public decimal WorkOrderSerial { get; set; }
        public string DCNumber { get; set; }
        public DateTime DCDate { get; set; }
        public string DCSerial { get; set; }
        public string PONumber { get; set; }
        public DateTime PODate { get; set; }
        public string POSerial { get; set; }
        public string DrawingNo { get; set; }
        public string DrawingRev { get; set; }
        public decimal PartCode { get; set; }
        public decimal WOQuantity { get; set; }
        public decimal Rate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal DCQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }
        public decimal InvoicedQuantity { get; set; }
        public decimal SCSentQuantity { get; set; }
        public decimal SCReceivedQuantity { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string ItemCode { get; set; }
        public string HeatNo { get; set; }
    }
}
