using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
   public class GetSubcontractProcessMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<SubcontractProcessMasterModel> GetSubcontractProcessMasterList { get; set; }
    }
}
