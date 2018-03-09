using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetWOMasterForDcResponseDto : BaseResponse
    {
        public List<GetWOMasterForDcResponse> getWOMasterForDcResponseList;
    }

    public class GetWOMasterForDcResponse
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public decimal WOQuantity { get; set; }
        public decimal PartCode { get; set; }
        public string PartDescription { get; set; }
        public string ItemCode { get; set; }
        public decimal MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public string DCNumber { get; set; }
        public string PONumber { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsNew { get; set; }
        public decimal DcSerial { get; set; }

        public List<GetSerialNoFromWoNumerWoSerialList> getSerialNoFromWoNumerWoSerialResponseList;
    }

    public class GetSerialNoFromWoNumerWoSerialList
    {
        public string SerialNo { get; set; }

        public string WONumber { get; set; }

        public string DCNumber { get; set; }

        public decimal WOSerial { get; set; }

        public bool IsDeletable { get; set; }

        public bool IsNew { get; set; }
    }
}
