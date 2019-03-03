using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
   public class UpdateDepartmentMasterCM
    {
        public decimal DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public string UpdatedBy { get; set; }
    }
}
