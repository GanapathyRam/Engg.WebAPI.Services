using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.SubContract
{
    public class SubContractRequestDto
    {
        public DateTime SubContractDcDate { get; set; }
        public string SubContractDcNumber { get; set; }
        public Int64 VendorCode { get; set; }
        public decimal SubContractSentFor { get; set; }
        public string Vehicle { get; set; }
        public string Remarks { get; set; }
        public bool Billable { get; set; }
        public bool IsNew { get; set; }

        public List<SubContractDetails> SubContractDetails { get; set; }
    }

    public class SubContractDetails
    {
        public string SubContractDcNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal PartCode { get; set; }

        public string ProcessDescription { get; set; }

        public bool IsNew { get; set; }

        public List<SubContractDetailsSerial> SubContractDetailsSerial { get; set; }
    }

    public class SubContractDetailsSerial
    {
        public string SubContractDcNumber { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public bool IsNew { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
