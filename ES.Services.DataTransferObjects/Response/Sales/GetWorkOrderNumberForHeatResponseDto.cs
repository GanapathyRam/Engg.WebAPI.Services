using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Sales
{
   public class GetWorkOrderNumberForHeatResponseDto : BaseResponse
    {
        public IEnumerable<GetWorkOrderNumberHeatResponseModel> getWorkOrderNumberHeatDetails { get; set; }
    }
    public class GetWorkOrderNumberHeatResponseModel
    {
        public string WONumber { get; set; }
    }
}
