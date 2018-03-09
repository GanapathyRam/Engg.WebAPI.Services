using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataAccess.Model.QueryModel.Despatch
{
    public class GetDcDetailsForInvoiceQM
    {
        public IEnumerable<GetDcDetailsForInvoiceModel> GetDcDetailsForInvoiceModel { get; set; }
    }
}
