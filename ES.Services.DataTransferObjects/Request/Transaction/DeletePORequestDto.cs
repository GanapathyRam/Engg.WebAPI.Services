using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class DeletePORequestDto
    {
        public string PONumber { get; set; }

        public decimal POSerialNo { get; set; }

        public int IsDeleteFrom { get; set; }
    }
}
