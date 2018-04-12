using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Production
{
    public class GetJobCardGenerationResponseDto : BaseResponse
    {
        public List<GetJobCardGenerationResponse> GetJobCardGenerationResponseList { get; set; }
    }

    public class GetJobCardGenerationResponse
    {
        public string SerialNo { get; set; }

        public decimal PartCode { get; set; }

        public string VendorName { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public string MaterialDescription { get; set; }

        public decimal SequenceNumber { get; set; }
    }
}
