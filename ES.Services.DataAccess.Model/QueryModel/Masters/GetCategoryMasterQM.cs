using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetCategoryMasterQM
    {
        public int RecordCount { get; set; }
        public IEnumerable<CategoryMasterModel> CategoryMasterList { get; set; }
    }
}
