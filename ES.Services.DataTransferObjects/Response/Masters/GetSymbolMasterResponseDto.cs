using ES.Services.DataTransferObjects.Response.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
   public class GetSymbolMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<SymbolMaster> SymbolMasterList { get; set; }
    }
}
