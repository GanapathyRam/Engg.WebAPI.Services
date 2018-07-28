using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetScReceivingDetailsResponseDto : BaseResponse
    {
        public List<GetSubContractReceivingResponse> getSubContractReceivingResponseList { get; set; }
    }

    public class GetSubContractReceivingResponse
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

        public List<GetSubContractReceivingSerialList> getSubContractReceivingSerialList { get; set; }
    }

    public class GetSubContractReceivingSerialList
    {
        public string SerialNo { get; set; }

        public string WONumber { get; set; }

        public decimal WOSerial { get; set; }
    }
}
