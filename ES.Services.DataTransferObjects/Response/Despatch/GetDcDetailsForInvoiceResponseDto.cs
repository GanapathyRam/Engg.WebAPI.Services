using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Response.Despatch
{
    public class GetDcDetailsForInvoiceResponseDto : BaseResponse
    {
        public IEnumerable<GetDcDetailsForInvoiceList> GetDcDetailsForInvoiceList { get; set; }
    }
}
