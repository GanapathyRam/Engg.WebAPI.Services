using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class DeliveryChallanRequestDto
    {
        public string WorkOrderType { get; set; }
        public DateTime DcDate { get; set; }
        public string DcNumber { get; set; }
        public Int64 VendorCode { get; set; }
        public string DcType { get; set; }
        public string VehicleNumber { get; set; }
        public bool Billable { get; set; }
        public bool IsNew { get; set; }

        public List<DcDetails> DcDetails { get; set; }
    }

    public class DcDetails
    {
        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public Int64 PartCode { get; set; }

        public decimal Quantity { get; set; }

        public string Remarks { get; set; }

        public bool InvoivedTag { get; set; }

        public string WoNumber { get; set; }

        public int WoSerial { get; set; }

        public bool IsNew { get; set; }

        public List<DcDetailSerial> DcDetailSerial { get; set; }
    }

    public class DcDetailSerial
    {
        public string DcNumber { get; set; }

        public decimal DcSerial { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public bool IsNew { get; set; }

        public Guid CreatedBy { get; set; }
            
        public DateTime CreatedDateTime { get; set; }
    }
}
