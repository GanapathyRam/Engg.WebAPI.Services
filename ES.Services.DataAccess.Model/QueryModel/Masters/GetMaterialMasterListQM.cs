using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetMaterialMasterListQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<MaterialMasterListForDropDown> MaterialMasterList { get; set; }
    }
}
