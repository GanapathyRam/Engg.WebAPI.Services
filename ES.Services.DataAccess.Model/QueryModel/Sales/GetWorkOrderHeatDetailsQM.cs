using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Sales
{
    public class GetWorkOrderHeatDetailsQM
    {
        public IEnumerable<GetWorkOrderHeatModel> getWorkOrderHeatDetails { get; set; }
    }

    public class GetWorkOrderHeatModel
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public string HeatNo { get; set; }
        public string SerialNo { get; set; }
        public string PartDescription { get; set; }
        public string DrawingNumber { get; set; }
        public string ItemCode { get; set; }
    }
}
