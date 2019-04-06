using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Transaction
{
    public class GetPOTypeResponseDto : BaseResponse
    {
        public IEnumerable<POTypeList> GetPOTypeList { get; set; }
    }
}
