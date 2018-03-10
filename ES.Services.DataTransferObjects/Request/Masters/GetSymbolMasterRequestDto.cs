using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Masters
{
    public class GetSymbolMasterRequestDto
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public decimal SymbolCode { get; set; }
    }
}
