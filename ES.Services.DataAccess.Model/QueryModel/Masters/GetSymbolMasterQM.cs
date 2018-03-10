using System;
using ES.Services.DataAccess.Model.QueryModel.Masters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.CommandModel.Masters
{
   public class GetSymbolMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<SymbolMasterModel> GetSymbolMasterList { get; set; }
    }
}
