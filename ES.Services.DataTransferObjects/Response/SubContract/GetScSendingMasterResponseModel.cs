using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetScSendingMasterResponseModel
    {
        public string SCDcNumber { get; set; }
        public DateTime ScDate { get; set; }
        public Int64 VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Vehicle { get; set; }
        public decimal SubContractSentFor { get; set; }
        public string ProcessDescription { get; set; }
        public string Remarks { get; set; }
    }
}
