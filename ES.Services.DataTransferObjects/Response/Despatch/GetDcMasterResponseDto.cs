using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetDcMasterResponseDto : BaseResponse
    {
      public List<GetDcMasterResponseModel> GetDcMasterResponseModelList { get; set; }
    }
}
