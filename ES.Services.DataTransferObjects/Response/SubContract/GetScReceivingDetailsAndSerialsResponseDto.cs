using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetScReceivingDetailsAndSerialsResponseDto : BaseResponse
    {
        public List<GetScReceivingDetailsResponse> getScReceivingDetailsResponse { get; set; }
    }

    public class GetScReceivingDetailsResponse
    {
        public string ScReceivingDcNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal PartCode { get; set; }

        public string PartDescription { get; set; }
        public string ItemCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string DrawingNumber { get; set; }
        public string ProcessDescription { get; set; }

        public bool IsNew { get; set; }

        public bool IsDeletable { get; set; }

        public List<GetScReceivingSerialsResponse> getGetScReceivingSerialsResponse;
    }

    public class GetScReceivingSerialsResponse
    {
        public string ScReceivingDcNumber { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public bool IsNew { get; set; }

        public bool IsDeletable { get; set; }

    }
}
