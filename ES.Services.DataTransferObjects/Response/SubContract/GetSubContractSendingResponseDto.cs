using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetSubContractSendingResponseDto : BaseResponse
    {
        public List<GetSubContractSendingResponse> getSubContractSendingResponseList { get; set; }
    }

    public class GetSubContractSendingResponse
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public string CustomerName { get; set; }
        public decimal PartCode { get; set; }
        public string PartDescription { get; set; }
        public string ItemCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string DrawingNumber { get; set; }
        //public bool IsDeletable { get; set; }
        //public bool IsNew { get; set; }
        //public string DCNumber { get; set; }

        public List<GetSubContractSendingSerialList> getSubContractSendingSerialList { get; set; }
    }

    public class GetSubContractSendingSerialList
    {
        public string SerialNo { get; set; }

        public string WONumber { get; set; }

        public decimal WOSerial { get; set; }
    }
}
