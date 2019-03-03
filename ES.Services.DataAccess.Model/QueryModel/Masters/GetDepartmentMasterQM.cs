using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetDepartmentMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<DepartmentMasterModel> DepartmentMasterList { get; set; }
    }

    public class DepartmentMasterModel
    {
        public decimal DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
