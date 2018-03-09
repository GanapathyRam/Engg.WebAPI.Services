using ES.Services.DataAccess.Model.QueryModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
    public class GetMaterialMasterQM    {
        public int RecordCount { get; set; }

        public IEnumerable<MaterialMasterModel> MaterialMasterList { get; set; }
    }
}
