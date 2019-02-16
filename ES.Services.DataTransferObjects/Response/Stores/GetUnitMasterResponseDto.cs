using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Stores
{
    public class GetUnitMasterResponseDto : BaseResponse
    {
        public IEnumerable<UnitMasterList> GetUnitMasterList { get; set; }
    }
}
