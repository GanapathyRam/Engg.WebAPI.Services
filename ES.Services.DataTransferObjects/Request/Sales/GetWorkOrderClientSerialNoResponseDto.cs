using ES.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Sales
{
    public class GetWorkOrderClientSerialNoResponseDto : BaseResponse
    {
        public string WorkOrderClientSerialNo { get; set; }
    }
}
