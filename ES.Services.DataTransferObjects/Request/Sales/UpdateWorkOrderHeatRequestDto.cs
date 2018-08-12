using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Sales
{
   public class UpdateWorkOrderHeatRequestDto
    {
        public List<UpdateWorkOrderHeatDetailsResponse> getWorkOrderHeatDetails { get; set; }
    }
    public class UpdateWorkOrderHeatDetailsResponse
    {
        public string WONumber { get; set; }
        public decimal WOSerial { get; set; }
        public string HeatNo { get; set; }
        public string SerialNo { get; set; }
    }
}
