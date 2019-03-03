using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
  public  class GetUnitMasterResponseDto: BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<UnitMaster> UnitMasterList { get; set; }
    }
    public class UnitMaster
    {
        public decimal UOMCode { get; set; }
        public string UOMDescription { get; set; }
    }
}
