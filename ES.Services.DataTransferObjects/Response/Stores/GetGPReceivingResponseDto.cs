using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GetGPReceivingResponseDto : BaseResponse
    {
       public List<GetGPReceivingMaster> getGPReceivingMaster { get; set; }
    }

    public class GetGPReceivingMaster
    {
        public string GPNumber { get; set; }

        public string GPType { get; set; }

        public DateTime GPDate { get; set; }

        public string VendorName { get; set; }

        public string RequestedBy { get; set; }

        public List<GetGPReceivingDetails> getGPReceivingDetails { get; set; }
    }

    public class GetGPReceivingDetails
    {
        public string GPNumber { get; set; }

        public int GPSerialNo { get; set; }

        public string Description { get; set; }

        public decimal Units { get; set; }

        public string UnitsDescription { get; set; }

        public decimal SentQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal BalanceQty { get; set; }
    }
}
