using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Production
{
    public class GetProcessCardQM
    {
        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public decimal PartCode { get; set; }

        public string PartDescription { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public string ItemCode { get; set; }

        public string SettingTime { get; set; }

        public string RunningTime { get; set; }

        public string MachineDescription { get; set; }

        public string JigDescription { get; set; }

        public IEnumerable<GetProcessCardQMModel> GetProcessCardDetailsQMModel;
    }

    public class GetProcessCardQMModel
    {
        public Int64 VendorCode { get; set; }

        public string VendorName { get; set; }

        public decimal PartCode { get; set; }

        public string ItemCode { get; set; }

        public string PartDescription { get; set; }

        public decimal SequenceNumber { get; set; }

        public string MachineCode { get; set; }

        public string JigCode { get; set; }

        public decimal SettingTime { get; set; }

        public decimal RunningTime { get; set; }

        public decimal SerialNo { get; set; }

        public string Description { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionMin { get; set; }

        public string ParameterCode { get; set; }

        public string ParameterDescription { get; set; }

        public string InstrumentCode { get; set; }

        public string InstrumentName { get; set; }

        public string ToolCode { get; set; }

        public string ToolDescription { get; set; }

        public bool DRFlag { get; set; }

        public string Symbol { get; set; }

        public string Datum { get; set; }

        public string DatumDimension { get; set; }

        public string BooleanNumber { get; set; }

        public string MachineDescription { get; set; }

        public string JigDescription { get; set; }

        public decimal MaxSerial { get; set; }
    }
}
