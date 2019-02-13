using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
   public class GPTypeMasterResponseDto : BaseResponse
    {
            public IEnumerable<GPTypeMasterResponse> gpTypeList { get; set; }  
    }

    public class GPTypeMasterResponse
    {
        public string GPType { get; set; }
        public string GPDescription { get; set; }
    }
}
