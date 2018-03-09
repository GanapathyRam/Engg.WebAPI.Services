using ES.Services.DataAccess.Model.CommandModel.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetMachineMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<MachineMasterModel> GetMachineMasterList { get; set; }
    }
}
