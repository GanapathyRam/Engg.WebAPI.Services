using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Sales
{
    public class GetJobCardEntryReportResponseDto : BaseResponse
    {
        public List<JobCardEntryCommon> getJobCardEntryCommonList { get; set; }
    }

    public class JobCardEntryCommon
    {
        public string CustomerName { get; set; }

        public string DrawingNumber { get; set; }

        public string WoNoAndSI { get; set; }

        public string Description { get; set; }

        public decimal PartCode { get; set; }

        public string PartDescription { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public List<JobCardEntryDetailsResponse> getJobCardEntryDetailsResponseList { get; set; }
    }

    public class JobCardEntryDetailsResponse
    {
        public string CustomerName { get; set; }

        public string DrawingNumber { get; set; }

        public string WoNoAndSI { get; set; }

        public string Description { get; set; }

        public decimal PartCode { get; set; }

        public string PartDescription { get; set; }

        public string WoNumber { get; set; }

        public decimal WoSerial { get; set; }

        public string SerialNo { get; set; }

        public string HeatNo { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal Serial { get; set; }
        
        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public string DimensionMin { get; set; }

        public string DimensionMax { get; set; }
    }
}
