using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Enquiry
{
    public class SalesEnquiryOptionRequestDto
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public Int16 WorkOrderType { get; set; }

        public Int16 Option { get; set; }

        public string Type { get; set; }
    }
}
