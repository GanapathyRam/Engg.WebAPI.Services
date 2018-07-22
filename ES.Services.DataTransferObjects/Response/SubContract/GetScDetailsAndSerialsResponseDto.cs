using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetScDetailsAndSerialsResponseDto : BaseResponse
    {
        public List<GetScDetailsResponse> getScDetailsResponse { get; set; }
    }

    public class GetScDetailsResponse
    {
        public string SubContractDcNumber { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public decimal PartCode { get; set; }

        public string ProcessDescription { get; set; }

        public bool IsNew { get; set; }

        public bool IsDeletable { get; set; }

        public List<GetScSerialsResponse> getGetScSerialsResponse;
    }

    public class GetScSerialsResponse
    {
        public string SubContractDcNumber { get; set; }

        public string SerialNo { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public bool IsNew { get; set; }

        public bool IsDeletable { get; set; }

    }
}
