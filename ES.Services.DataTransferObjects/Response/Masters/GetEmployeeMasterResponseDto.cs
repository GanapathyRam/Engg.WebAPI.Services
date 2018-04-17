using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class GetEmployeeMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }
        public IEnumerable<EmployeeMasterResponse> EmployeeMasterResponseList { get; set; }
    }

    public class EmployeeMasterResponse
    {
        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }
    }
}
