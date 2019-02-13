using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Stores
{
    public class GPTypeMasterQM
    {
        public IEnumerable<GPTypeMasterResponseModel> gpTypeList { get; set; }
    }
    public class GPTypeMasterResponseModel
    {
        public string GPType { get; set; }
        public string GPDescription { get; set; }
    }
}
