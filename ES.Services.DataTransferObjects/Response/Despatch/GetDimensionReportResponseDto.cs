using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetDimensionReportResponseDto : BaseResponse
    {
        public List<GetDimensionReportResponse> getDimensionReportResponseList { get; set; }
    }

    public class GetDimensionReportResponse
    {
        public string CustomerName { get; set; }

        public string Description { get; set; }

        public string PoNumber { get; set; }

        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public string DrawingNo { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string MaterialDescription { get; set; }

        public decimal PartCode { get; set; }

        public string ItemCode { get; set; }

        public decimal Quantity { get; set; }

        public char Units { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string UnitDescription { get; set; }

        public List<DimensionReportSerialList> getDimensionReportSerialList { get; set; }

        public List<DimensionReportSequenceList> getDimensionReportSequenceList { get; set; }
    }

    public class DimensionReportSerialList
    {
        public string SerialNo { get; set; }

        public string HeatNo { get; set; }
    }

    public class DimensionReportSequenceList
    {
        public decimal SequenceNumber { get; set; }

        public decimal Serial { get; set; }

        public string Description { get; set; }

        public string DimensionMin { get; set; }

        public string DimensionMax { get; set; }

        public string InstrumentDescription { get; set; }

        //public List<DimensionReportProcessDetails> getDimensionReportProcessDetails { get; set; }

        public List<DimensionReportBySerial> getDimensionReportBySerial { get; set; }

    }

    //public class DimensionReportProcessDetails
    //{
    //    public List<DimensionReportBySerial> getDimensionReportBySerial { get; set; }

    //}

    public class DimensionReportBySerial
    {
        public decimal Serial { get; set; }

        public string SerialNo { get; set; }

        public decimal SequenceNumber { get; set; }

        public string DimensionActual { get; set; }
    }

}
