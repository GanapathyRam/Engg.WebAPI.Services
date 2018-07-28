using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.SubContract
{
    public class SubContractReceivingRequestDto
    {
        public DateTime ScReceivingDcDate { get; set; }
        public string ScReceivingDcNumber { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorDCNumber { get; set; }
        public DateTime ScReceivingVendorDate { get; set; }
        public string Vehicle { get; set; }
        public string Remarks { get; set; }
        public bool Billable { get; set; }
        public bool IsNew { get; set; }

        public List<SubContractReceivingDetails> SubContractReceivingDetails { get; set; }
    }

    public class SubContractReceivingDetails
    {
        public string ScReceivingDcNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal PartCode { get; set; }

        public string ProcessDescription { get; set; }

        public bool IsNew { get; set; }

        public List<SubContractReceivingDetailsSerial> SubContractReceivingDetailsSerial { get; set; }
    }

    public class SubContractReceivingDetailsSerial
    {
        public string ScReceivingDcNumber { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public bool IsNew { get; set; }

        public bool IsReceived { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
