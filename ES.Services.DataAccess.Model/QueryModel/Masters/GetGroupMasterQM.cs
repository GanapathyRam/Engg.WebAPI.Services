using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Masters
{
    public class GetGroupMasterQM
    {
        public int RecordCount { get; set; }

        public IEnumerable<GroupMasterModel> GroupMasterList { get; set; }
    }
}
