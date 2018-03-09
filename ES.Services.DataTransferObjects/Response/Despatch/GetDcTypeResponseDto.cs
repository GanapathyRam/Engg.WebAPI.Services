using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetDcTypeResponseDto : BaseResponse
    {
        public IEnumerable<DcTypeList> DcTypeList { get; set; }
    }
}
