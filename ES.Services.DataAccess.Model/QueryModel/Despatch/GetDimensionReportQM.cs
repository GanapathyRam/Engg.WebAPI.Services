using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetDimensionReportQM
    {
        public IEnumerable<GetDimensionReportModel> getDimensionReportModel { get; set; }
    }

    public class GetDimensionReportModel
    {
        public string SerialNo { get; set; }

        public string HeatNo { get; set; }

        public string PartDescription { get; set; }

        public string DrawingNumber { get; set; }

        public string DrawingNumberRevision { get; set; }

        public string ItemCode { get; set; }

        public string MaterialShortDescription { get; set; }

        public string VendorName { get; set; }

        public decimal SequenceNumber { get; set; }

        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public string Description { get; set; }

        public string DimensionMin { get; set; }

        public string DimensionMax { get; set; }

        public string InstrumentName { get; set; }

        public char Unit { get; set; }

        public string UnitDescription { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal InvoiceSerial { get; set; }

        public string PartCode { get; set; }

        public decimal Quantity { get; set; }

        public decimal Serial { get; set; }

        public string PONumber { get; set; }

        public string DimensionActual { get; set; }
    }
}
