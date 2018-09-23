using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Enquiry
{
    public class DespatchEnquiryOptionRequestDto
    {
        public Int16 Option { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set;  }
    }
}
