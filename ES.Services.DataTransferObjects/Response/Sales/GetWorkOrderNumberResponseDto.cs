using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Sales
{
    public class GetWorkOrderNumberResponseDto : BaseResponse
    {
        public string WorkOrderNumber { get; set; }
    }
}
