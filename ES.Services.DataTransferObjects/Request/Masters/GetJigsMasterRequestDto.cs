using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class GetJigsMasterRequestDto
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public decimal JigsCode { get; set; }
    }
}
