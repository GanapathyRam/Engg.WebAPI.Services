using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Production
{
    public class GetProcessCardDetailsQM
    {
        public IEnumerable<GetProcessCardDetailsQMModel> GetProcessCardDetailsQMModelList { get; set; }
    }

    public class GetProcessCardDetailsQMModel
    {
        public decimal PartCode { get; set; }

        public decimal SequenceNumber { get; set; }

        public string SerialNo { get; set; }

        public decimal Serial { get; set; }

        public string Description { get; set; }

        public string DimensionMax { get; set; }

        public string DimensionMin { get; set; }

        public string ParameterCode { get; set; }

        public string InstrumentCode { get; set; }

        public string ToolCode { get; set; }

        public bool DRFlag { get; set; }

        public string Symbol { get; set; }

        public string Datum { get; set; }

        public string DatumDimension { get; set; }

        public string BooleanNumber { get; set; }

        public string DatumDimensionActual { get; set; }

        public string DimensionActual { get; set; }
    }
}
