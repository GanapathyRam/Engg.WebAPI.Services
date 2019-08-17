using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class DeleteGRNRequestDto
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public int IsDeleteFrom { get; set; }
    }
}
