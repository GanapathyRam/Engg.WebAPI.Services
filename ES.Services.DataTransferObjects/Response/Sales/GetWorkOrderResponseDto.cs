using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Sales
{
    public class GetWorkOrderResponse
    {
        public string WorkOrderType { get; set; }
        public string WorkOrderNumber { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal MaxSerial { get; set; }
        public string VendorName { get; set; }

        public List<GetWorkOrderMasterDetailsResponse> getWorkOrderMasterDetailsResponse { get; set; }
    }

    public class GetWorkOrderResponseDto : BaseResponse
    {
        public List<GetWorkOrderResponse> GetWorkOrderResponse { get; set; }
    }

    public class GetWorkOrderMasterDetailsResponse
    {
        public string WorkOrderType { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public string WorkOrderNumber { get; set; }
        public decimal WorkOrderSerial { get; set; }
        public string DCNumber { get; set; }
        public DateTime DCDate { get; set; }
        public string DCSerial { get; set; }
        public string DrawingNo { get; set; }
        public string DrawingRev { get; set; }
        public decimal PartCode { get; set; }
        public decimal WOQuantity { get; set; }
        public decimal Rate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string ItemCode { get; set; }
        public string HeatNo { get; set; }
       // public string SerialNo { get; set; }
        public string PONumber { get; set; }
        public DateTime PODate { get; set; }
        public string POSerial { get; set; }
        public string PartDescription { get; set; }
        public string MaterialDescription { get; set; }
        public string VendorName { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsNew { get; set; }
        public decimal MaxSerial { get; set; }
        public bool IsDelete { get; set; }

    }
}
