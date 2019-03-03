using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
   public class GetGroupMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<GroupMaster> GroupMasterList { get; set; }
    }

    public class GroupMaster
    {
        public decimal GroupCode { get; set; }
        public string GroupDescription { get; set; }
    }
}
