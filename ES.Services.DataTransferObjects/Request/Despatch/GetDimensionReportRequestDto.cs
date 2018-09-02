using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Despatch
{
    public class GetDimensionReportRequestDto
    {
        public string InvoiceNumber { get; set; }

        public decimal InvoiceSerial { get; set; }

        public int IsReportFor { get; set; }
    }
}
