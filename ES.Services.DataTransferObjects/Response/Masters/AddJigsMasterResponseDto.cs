using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Masters
{
    public class AddJigsMasterResponseDto : BaseResponse
    {
        public int RecordCount { get; set; }

        public IEnumerable<JigsMaster> JigsMasterList { get; set; }
    }
}
