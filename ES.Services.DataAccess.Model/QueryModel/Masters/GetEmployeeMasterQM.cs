using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetEmployeeMasterQM
    {
        public int RecordCount { get; set; }
        public IEnumerable<EmployeeMasterModel> EmployeeMasterList { get; set; }
    }

    public class EmployeeMasterModel
    {
        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }
    }
}
