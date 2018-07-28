using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.SubContract
{
    public class GetScReceivingMasterResponseDto : BaseResponse
    {
        public List<GetScReceivingMasterResponseModel> GetScReceivingMasterResponseModel { get; set; }
    }
}
