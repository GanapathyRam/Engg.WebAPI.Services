using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Sales
{
    public class UpdateWorkOrderHeatCM
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public string HeatNo { get; set; }
        public string SerialNo { get; set; }
    }
}
