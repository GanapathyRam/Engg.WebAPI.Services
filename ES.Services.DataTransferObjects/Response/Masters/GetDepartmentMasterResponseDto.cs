using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
   public class GetDepartmentMasterResponseDto: BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<DepartmentMaster> DepartmentMasterList { get; set; }
    }

    public class DepartmentMaster
    {
        public decimal DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
